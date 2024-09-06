using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Diagnostics;
using System.Threading;

public partial class MainForm : Form
{
    private List<Game> games = new List<Game>();
    private CancellationTokenSource cancellationTokenSource;

    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
       
    }

    private void LoadGames(string filePath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            HeaderValidated = null,
            MissingFieldFound = null,
            BadDataFound = null
        };

        try
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<GameMap>();
                games = csv.GetRecords<Game>().ToList();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error while loading the games: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

 
    private void SearchGames(string query)
    {
        var results = games.Where(g => g.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        resultsListBox.DataSource = results;
        resultsListBox.DisplayMember = "Title";
    }

    private void searchTextBox_TextChanged(object sender, EventArgs e)
    {
        SearchGames(searchTextBox.Text);
    }

    private void resultsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Work in Progress
    }

    private async void downloadButton_Click(object sender, EventArgs e)
    {
        if (resultsListBox.SelectedItem is Game selectedGame)
        {
            var result = MessageBox.Show($"You really wanna download '{selectedGame.Title}'?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PKG files (*.pkg)|*.pkg|All files (*.*)|*.*";
                    saveFileDialog.FileName = selectedGame.Title;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = saveFileDialog.FileName;
                        cancellationTokenSource = new CancellationTokenSource();
                        cancelButton.Visible = true;
                        await DownloadGame(selectedGame.Url, savePath, cancellationTokenSource.Token);
                        cancelButton.Visible = false;
                        MessageBox.Show($"Download Complete!", "Download Complete!", MessageBoxButtons.OK);
                    }
                }
            }
        }
    }

    private async Task DownloadGame(string url, string savePath, CancellationToken cancellationToken)
    {
        using (var client = new HttpClient())
        {
            try
            {
                var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
                response.EnsureSuccessStatusCode();

                var totalBytes = response.Content.Headers.ContentLength ?? 1;
                var buffer = new byte[8192];
                var bytesRead = 0L;
                var totalRead = 0L;
                var stopwatch = Stopwatch.StartNew();

                using (var contentStream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None, buffer.Length, true))
                {
                    while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, (int)bytesRead, cancellationToken);
                        totalRead += bytesRead;
                        var downloadRate = totalRead / (stopwatch.Elapsed.TotalSeconds * 1024 * 1024); // MB/s
                        downloadProgressBar.Value = (int)((totalRead * 100L) / totalBytes);
                        downloadProgressLabel.Text = $"{(totalRead / (1024 * 1024)):0.00}/{(totalBytes / (1024 * 1024)):0.00} MB ({downloadRate:0.00} MB/s)";
                        downloadProgressBar.Refresh();
                        downloadProgressLabel.Refresh();
                    }
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Download was terminated.", "Download Terminated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error occured while downloading!: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        cancellationTokenSource?.Cancel();
    }

    private void browseButton_Click(object sender, EventArgs e)
    {
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathTextBox.Text = openFileDialog.FileName;
                LoadGames(openFileDialog.FileName);
            }
        }
    }
}

public class Game
{
    public string ID { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public string Region { get; set; }
    public string Url { get; set; }
    public string Rap { get; set; }
    public string Hash { get; set; }
    public string Description { get; set; }
}

public class GameMap : ClassMap<Game>
{
    public GameMap()
    {
        Map(m => m.ID).Index(0);
        Map(m => m.Title).Index(1);
        Map(m => m.Type).Index(2);
        Map(m => m.Region).Index(3);
        Map(m => m.Url).Index(4);
        Map(m => m.Rap).Index(5);
        Map(m => m.Hash).Index(6);
        Map(m => m.Description).Index(7);
    }
}
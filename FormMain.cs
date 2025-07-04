using System.Collections.Generic;
using System.Drawing.Text;
using System.Runtime.Intrinsics.X86;

namespace NightreignWeaponScaling;

public partial class FormMain : Form
{
    private enum OutputModes
    {
        Categories, Nightfarer
    }

    private OutputModes _outputMode;
    private List<Nightfarer> _nightfarers;
    private List<WeaponCategory> _weaponCategories;

    public FormMain()
    {
        InitializeComponent();

        _nightfarers =
        [
            new Nightfarer("Wylder", 'A', 'B', 'C', 'C', 'C'),
            new Nightfarer("Guardian", 'B', 'C', 'D', 'C', 'C'),
            new Nightfarer("Ironeye", 'C', 'A', 'D', 'D', 'B'),
            new Nightfarer("Duchess", 'D', 'B', 'A', 'B', 'C'),
            new Nightfarer("Raider", 'S', 'C', 'D', 'D', 'C'),
            new Nightfarer("Revenant", 'C', 'C', 'B', 'S', 'B'),
            new Nightfarer("Recluse", 'D', 'C', 'S', 'S', 'C'),
            new Nightfarer("Executor", 'C', 'S', 'D', 'D', 'S'),
            new Nightfarer("Pure Strength", 'S', '-', '-', '-', '-'),
            new Nightfarer("Pure Dexterity", '-', 'S', '-', '-', '-'),
            new Nightfarer("Pure Balance", 'B', 'B', '-', '-', '-'),
            new Nightfarer("Balance, Strength Bias", 'A', 'B', '-', '-', '-'),
            new Nightfarer("Balance, Dexterity Bias", 'B', 'A', '-', '-', '-')
        ];

        // Add Nightfarers to combo box
        foreach (Nightfarer nightfarer in _nightfarers)
            comboBoxNightfarers.Items.Add(nightfarer.Name);

        // Add output modes to combo box
        foreach (string outputMode in Enum.GetNames(typeof(OutputModes)))
            comboBoxOutputMode.Items.Add(outputMode);
        comboBoxOutputMode.SelectedIndex = 0;
        _outputMode = 0;

    } // end constructor

    /// <summary>
    /// Info file browse button clicked.
    /// </summary>
    private void buttonBrowse_Click(object sender, EventArgs e)
    {
        OpenFileDialog file = new OpenFileDialog();
        if (file.ShowDialog() == DialogResult.OK)
            textBoxFilePath.Text = file.FileName;

        ParseInfoFile();

    } // end buttonBrowse_Click

    /// <summary>
    /// Obsidian formatting checkbox changed.
    /// </summary>
    private void checkBoxObsidianFormat_CheckedChanged(object sender, EventArgs e)
    {
        UpdateOutput();

    } // end checkBoxObsidianFormat_CheckedChanged

    /// <summary>
    /// Newline checkbox changed.
    /// </summary>
    private void checkBoxNewline_CheckedChanged(object sender, EventArgs e)
    {
        UpdateOutput();

    } // end checkBoxNewline_CheckedChanged

    /// <summary>
    /// Nightfarer drop-down box changed.
    /// </summary>
    private void comboBoxNightfarers_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateOutput();

    } // end comboBoxNightfarers_SelectedIndexChanged

    /// <summary>
    /// Output mode drop-down box changed.
    /// </summary>
    private void comboBoxOutputMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        _outputMode = (OutputModes)comboBoxOutputMode.SelectedIndex;
        UpdateOutput();

    } // end comboBoxOutputMode_SelectedIndexChanged

    /// <summary>
    /// Updates the text output.
    /// </summary>
    private void UpdateOutput()
    {
        // Errors
        if (!File.Exists(textBoxFilePath.Text))
        {
            textBoxOutput.Text = "Invalid weapon info file path.";
            return;
        }
        else if (comboBoxNightfarers.Text == string.Empty)
        {
            textBoxOutput.Text = "No Nightfarer is selected.";
            return;
        }
        else if (_weaponCategories == null)
        {
            textBoxOutput.Text = "No weapon categories generated.";
            return;
        }

        // Get Nightfarer
        Nightfarer nightfarer = null;
        for (int i = 0; i < _nightfarers.Count; i++)
        {
            if (comboBoxNightfarers.Text == _nightfarers[i].Name)
                nightfarer = _nightfarers[i];
        }
        if (nightfarer == null)
        {
            textBoxOutput.Text = "Invalid Nightfarer.";
            return;
        }

        SortedDictionary<int, List<ScoredWeapon>> weaponsGroupedByScore = SortWeapons(nightfarer);
        textBoxOutput.Text = string.Empty;
        // Obsidian format 'header'
        if (checkBoxObsidianFormat.Checked)
        {
            textBoxOutput.AppendText("> [!abstract]- Weapon Scaling (highest to lowest)\r\n");
            textBoxOutput.AppendText("> _(Calculated with [NightreignWeaponScaling](https://github.com/oinkratpig/NightreignWeaponScaling))._\r\n");
        }
        int j = 1;
        foreach (int score in weaponsGroupedByScore.Keys)
        {
            // Sort list
            ScoredWeapon[] sortedWeapons = weaponsGroupedByScore[score].OrderBy(x => x.Name).ToArray();

            // Print group
            string line = string.Empty;
            if (checkBoxObsidianFormat.Checked)
                line += "> ";
            // Grouped weapon scores are separated by commas
            if (!checkBoxNewline.Checked)
            {
                line += $"{j}. ";
                bool first = true;
                foreach (ScoredWeapon weapon in sortedWeapons)
                {
                    if (!first)
                        line += ", ";
                    else
                        first = false;
                    line += weapon.Name;
                }
                line += "\r\n";
            }
            // Group scores are added to a new line
            else
            {
                // Get letter displayed after a grouped rank
                string bulletLetter(int index)
                {
                    char firstChar = 'A';
                    int alphabetSize = 26;

                    string result = string.Empty;
                    while (index > 0)
                    {
                        index--;
                        result = (char)(firstChar + (index % alphabetSize)) + result;
                        index /= alphabetSize;
                    }

                    return result;
                }

                // Display each weapon on newline
                int ind = 1;
                foreach (ScoredWeapon weapon in sortedWeapons)
                {
                    bool includeChar = true;
                    if (weaponsGroupedByScore[score].Count == 1)
                        includeChar = false;
                    line += $"{j}{((includeChar) ? bulletLetter(ind++) : "")}. {weapon.Name}\r\n";
                }
            }

            // Escape square brackets if formatting for Obsidian
            if (checkBoxObsidianFormat.Checked)
                line = line.Replace("[", "**\\[").Replace("]", "\\]**");

            textBoxOutput.AppendText(line);
            j++;
        }
        textBoxOutput.Text = textBoxOutput.Text.Remove(textBoxOutput.Text.LastIndexOf(Environment.NewLine));

    } // end UpdateOutput

    /// <summary>
    /// Returns weapons grouped together by score within a sorted dictionary.
    /// </summary>
    private SortedDictionary<int, List<ScoredWeapon>> SortWeapons(Nightfarer nightfarer)
    {
        SortedDictionary<int, List<ScoredWeapon>> groupedAndSorted = new();

        // Add new weapon to a score group
        void addToGroup(string weaponName, ScalingSet scalings)
        {
            ScoredWeapon weapon = new ScoredWeapon(weaponName, scalings, nightfarer);
            int score = -weapon.Score;

            // Group existing scores together
            if (groupedAndSorted.ContainsKey(score))
                groupedAndSorted[score].Add(weapon);
            // New score
            else
                groupedAndSorted[score] = new() { weapon };
        }

        // Group all weapon scalings by score within a sorted dictionary
        foreach (WeaponCategory weaponCategory in _weaponCategories)
        {
            // Categories style
            if (_outputMode == OutputModes.Categories)
            {
                addToGroup(weaponCategory.Name, weaponCategory.AverageScalings);
            }
            // Nightfarer style
            else if (_outputMode == OutputModes.Nightfarer)
            {
                addToGroup($"[{weaponCategory.Name}]", weaponCategory.AverageScalings);
                foreach (Weapon uniqueWeapon in weaponCategory.UniquelyScaledWeapons)
                    addToGroup(uniqueWeapon.Name, uniqueWeapon.Scalings);
            }
        }

        return groupedAndSorted;

    } // end RankWeapons

    /// <summary>
    /// Parse the info file.
    /// </summary>
    public void ParseInfoFile()
    {
        // Read lines
        List<string> lines = new List<string>();
        try
        {
            using (StreamReader reader = new StreamReader(textBoxFilePath.Text))
            {
                string? line;
                while (true)
                {
                    line = reader.ReadLine();
                    if (line != null)
                        lines.Add(line);
                    else break;
                }
            }
        }
        catch (Exception e)
        {
            textBoxOutput.Text = e.Message;
        }

        // Parse lines
        _weaponCategories = new List<WeaponCategory>();
        WeaponCategory? weaponCategory = null;
        foreach (string line in lines)
        {
            // New weapon category
            // (Denoted by line starting with #)
            if (line[0] == '#')
            {
                if (weaponCategory != null)
                    _weaponCategories.Add(weaponCategory);

                string[] lineInfo = line.Substring(1).Split(',');
                weaponCategory = new WeaponCategory(lineInfo[0], char.Parse(lineInfo[1]), char.Parse(lineInfo[2]), char.Parse(lineInfo[3]), char.Parse(lineInfo[4]), char.Parse(lineInfo[5]));
            }
            // Tried to add weapon but no category
            else if (weaponCategory == null)
            {
                textBoxOutput.Text = "Tried to add a weapon to a nonexistence weapon category. Something's wrong with your info file.";
                break;
            }
            // Weapon
            else
            {
                string[] lineInfo = line.Split(',');
                Weapon weapon = new Weapon(lineInfo[0], char.Parse(lineInfo[1]), char.Parse(lineInfo[2]), char.Parse(lineInfo[3]), char.Parse(lineInfo[4]), char.Parse(lineInfo[5]));
                if (!weapon.AreScalingsSame(weaponCategory.AverageScalings))
                    weaponCategory.UniquelyScaledWeapons.Add(weapon);
            }
        }
        if (_weaponCategories != null)
            _weaponCategories.Add(weaponCategory);

        // Update output
        UpdateOutput();

    } // end ParseInfoFile

} // end class FormMain
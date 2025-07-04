using System.Runtime.Intrinsics.X86;

namespace NightreignWeaponScaling;

public partial class FormMain : Form
{
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
    /// Nightfarer drop-down box changed.
    /// </summary>
    private void comboBoxNightfarers_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateOutput();

    } // end comboBoxNightfarers_SelectedIndexChanged

    // Update text output
    private void UpdateOutput()
    {
        // Errors
        if (comboBoxNightfarers.Text == string.Empty)
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
        for(int i = 0; i < _nightfarers.Count; i++)
        {
            if(comboBoxNightfarers.Text == _nightfarers[i].Name)
                nightfarer = _nightfarers[i];
        }
        if(nightfarer == null)
        {
            textBoxOutput.Text = "Invalid Nightfarer.";
            return;
        }

        ScoredWeapon[] sortedWeapons = SortWeapons(nightfarer);
        textBoxOutput.Text = string.Empty;
        for (int i = 0; i < sortedWeapons.Length; i++)
        {
            textBoxOutput.AppendText($"> {i + 1}. {sortedWeapons[i].Name} (Score: {sortedWeapons[i].Score})\r\n");
        }

    } // end UpdateOutput

    private ScoredWeapon[] SortWeapons(Nightfarer nightfarer)
    {
        // List of all weapon scalings
        List<ScoredWeapon> scoredWeapons = new List<ScoredWeapon>();
        foreach(WeaponCategory weaponCategory in _weaponCategories)
        {
            // Category's average scalings
            scoredWeapons.Add(new ScoredWeapon($"[{weaponCategory.Name.ToUpper()}]", weaponCategory.AverageScalings, nightfarer));
            // Individual, unqiue weapons
            /*
            foreach (Weapon uniqueWeapon in weaponCategory.UniquelyScaledWeapons)
                scoredWeapons.Add(new ScoredWeapon(uniqueWeapon.Name, uniqueWeapon.Scalings, nightfarer));
            */
        }

        // Sort list
        return scoredWeapons.OrderByDescending(x => x.Score).ToArray();

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
        foreach(string line in lines)
        {
            // New weapon category
            // (Denoted by line starting with #)
            if(line[0] == '#')
            {
                if (weaponCategory != null)
                    _weaponCategories.Add(weaponCategory);

                string[] lineInfo = line.Substring(1).Split(',');
                weaponCategory = new WeaponCategory(lineInfo[0], char.Parse(lineInfo[1]), char.Parse(lineInfo[2]), char.Parse(lineInfo[3]), char.Parse(lineInfo[4]), char.Parse(lineInfo[5]));
            }
            // Tried to add weapon but no category
            else if(weaponCategory == null)
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
        if(_weaponCategories != null)
            _weaponCategories.Add(weaponCategory);

        // Update output
        UpdateOutput();

    } // end ParseInfoFile

} // end class FormMain
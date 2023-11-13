using Tommy;
namespace TOMLrt;

public class Settings
{
    TomlTable _settings;

    List<Machine>? _machines;

    public string Site => _settings["site"];

    /// <summary>
    /// Reads in the default settings file
    /// </summary>
    /// <param name="file"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="Exception"></exception>
    public Settings(string file)
    {
        if (file == null)
            throw new ArgumentNullException(nameof(file));
        if (!File.Exists(file))
            throw new FileNotFoundException("Settings file not found", file);
        if (Path.GetExtension(file) != ".toml")
            throw new ArgumentException("Settings file must be a TOML file", nameof(file));

        try
        {
            StreamReader streamReader = File.OpenText(file);
            _settings = TOML.Parse(streamReader);
        }
        catch (Exception ex)
        {
            throw new Exception("Error reading settings file", ex);
        }
    }



    public bool HasMachine(string name)
    {
        return GetMachines().Any(m => m.Name == name);
    }

    public Machine GetMachine(string name)
    {
        return GetMachines().FirstOrDefault(m => m.Name == name);
    }

    public bool HasMachines()
    {
        return _settings["machines"] != null;
    }



    public List<Machine> GetMachines()
    {
        if (_machines == null)
        {
            _machines = new List<Machine>();
            foreach (TomlTable table in _settings["machines"])
            {
                List<string> photons, electrons, fff, tags;

                photons = new List<string>();
                foreach (TomlNode value in table["photons"])
                {
                    photons.Add(value);
                }

                electrons = new List<string>();
                foreach (TomlNode value in table["electrons"])
                {
                    electrons.Add(value);
                }

                fff = new List<string>();
                foreach (TomlNode value in table["fff"])
                {
                    fff.Add(value);
                }

                tags = new List<string>();

                foreach (TomlNode value in table["tags"])
                {
                    tags.Add(value);
                }


                _machines.Add(new Machine
                {
                    Name = table["name"],
                    Model = table["model"],
                    MLC = table["mlc"],
                    ID = table["id"],
                    Photons = photons.ToArray(),
                    Electrons = electrons.ToArray(),
                    FFF = fff.ToArray(),
                    Tags = tags.ToArray()
                });
            }
        }
        return _machines;
    }



}



public record Machine
{
    public string Name { get; init; }
    public string Model { get; init; }
    public string MLC { get; init; }
    public string ID { get; init; }
    public string[] Photons { get; init; }
    public string[] Tags { get; init; }
    public string[] Electrons { get; init; }
    public string[] FFF { get; init; }



}




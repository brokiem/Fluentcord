using NetCord;

namespace Fluentcord.Models.Messages.Embed;

public class EmbedFieldsModel : ModelBase
{
    public string Name { get; set; }
    public string Value { get; set; }
    public bool? Inline { get; set; }

    public EmbedFieldsModel(string name, string value, bool? inline = null)
    {
        Name = name;
        Value = value;
        Inline = inline;
    }

    public EmbedFieldsModel(EmbedField embedField)
    {
        Name = embedField.Name;
        Value = embedField.Value;
        Inline = embedField.Inline;
    }
}
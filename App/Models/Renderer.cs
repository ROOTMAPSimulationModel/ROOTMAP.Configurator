//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

//
// This source code was auto-generated by xsd, Version=4.7.2046.0.
//
namespace Rootmap.Configurator.Schema.Renderer
{
  using System.Xml.Serialization;


  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://example.org/ROOTMAP/ViewSchema")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "https://example.org/ROOTMAP/ViewSchema", IsNullable = false)]
  public partial class rootmap
  {

    private Renderer initialisationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public Renderer initialisation
    {
      get
      {
        return this.initialisationField;
      }
      set
      {
        this.initialisationField = value;
      }
    }
  }

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "https://example.org/ROOTMAP/ViewSchema")]
  public partial class Renderer
  {

    private string ownerField;

    private CharacteristicColourInfo[] characteristic_colour_infoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public string owner
    {
      get
      {
        return this.ownerField;
      }
      set
      {
        this.ownerField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("characteristic_colour_info", Order = 1)]
    public CharacteristicColourInfo[] characteristic_colour_info
    {
      get
      {
        return this.characteristic_colour_infoField;
      }
      set
      {
        this.characteristic_colour_infoField = value;
      }
    }
  }

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "https://example.org/ROOTMAP/ViewSchema")]
  public partial class CharacteristicColourInfo
  {

    private int colour_minField;

    private int colour_maxField;

    private decimal characteristic_minField;

    private decimal characteristic_maxField;

    private string process_nameField;

    private string characteristic_nameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public int colour_min
    {
      get
      {
        return this.colour_minField;
      }
      set
      {
        this.colour_minField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    public int colour_max
    {
      get
      {
        return this.colour_maxField;
      }
      set
      {
        this.colour_maxField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    public decimal characteristic_min
    {
      get
      {
        return this.characteristic_minField;
      }
      set
      {
        this.characteristic_minField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    public decimal characteristic_max
    {
      get
      {
        return this.characteristic_maxField;
      }
      set
      {
        this.characteristic_maxField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    public string process_name
    {
      get
      {
        return this.process_nameField;
      }
      set
      {
        this.process_nameField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
    public string characteristic_name
    {
      get
      {
        return this.characteristic_nameField;
      }
      set
      {
        this.characteristic_nameField = value;
      }
    }
  }
}

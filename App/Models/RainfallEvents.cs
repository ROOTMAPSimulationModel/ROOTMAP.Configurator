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
namespace Rootmap.Configurator.Schema.RainfallEvents
{
  using System.Xml.Serialization;


  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://example.org/ROOTMAP/RainfallEventsSchema")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "https://example.org/ROOTMAP/RainfallEventsSchema", IsNullable = false)]
  public partial class rootmap
  {

    private RainfallEvents initialisationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public RainfallEvents initialisation
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
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "https://example.org/ROOTMAP/RainfallEventsSchema")]
  public partial class RainfallEvents
  {

    private string ownerField;

    private RainfallEventsData dataField;

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
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    public RainfallEventsData data
    {
      get
      {
        return this.dataField;
      }
      set
      {
        this.dataField = value;
      }
    }
  }

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://example.org/ROOTMAP/RainfallEventsSchema")]
  public partial class RainfallEventsData
  {

    private RainfallEventsDataFloatarray floatarrayField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public RainfallEventsDataFloatarray floatarray
    {
      get
      {
        return this.floatarrayField;
      }
      set
      {
        this.floatarrayField = value;
      }
    }
  }

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://example.org/ROOTMAP/RainfallEventsSchema")]
  public partial class RainfallEventsDataFloatarray
  {

    private string nameField;

    private string valueField;

    public RainfallEventsDataFloatarray()
    {
      this.nameField = "Rainfall Events";
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
      get
      {
        return this.nameField;
      }
      set
      {
        this.nameField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
      get
      {
        return this.valueField;
      }
      set
      {
        this.valueField = value;
      }
    }
  }
}

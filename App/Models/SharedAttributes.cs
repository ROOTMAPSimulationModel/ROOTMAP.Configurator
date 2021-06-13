﻿//------------------------------------------------------------------------------
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
namespace Rootmap.Configurator.Schema.SharedAttributes
{
  using System.Xml.Serialization;


  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://example.org/ROOTMAP/SharedAttributesSchema")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "https://example.org/ROOTMAP/SharedAttributesSchema", IsNullable = false)]
  public partial class rootmap
  {

    private SharedAttributes constructionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public SharedAttributes construction
    {
      get
      {
        return this.constructionField;
      }
      set
      {
        this.constructionField = value;
      }
    }
  }

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "https://example.org/ROOTMAP/SharedAttributesSchema")]
  public partial class SharedAttributes
  {

    private string ownerField;

    private SharedAttributesAttribute[] attributeField;

    public SharedAttributes()
    {
      this.ownerField = "SharedAttributeManager";
    }

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
    [System.Xml.Serialization.XmlElementAttribute("attribute", Order = 1)]
    public SharedAttributesAttribute[] attribute
    {
      get
      {
        return this.attributeField;
      }
      set
      {
        this.attributeField = value;
      }
    }
  }

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://example.org/ROOTMAP/SharedAttributesSchema")]
  public partial class SharedAttributesAttribute
  {

    private string ownerField;

    private Characteristic characteristic_descriptorField;

    private string storageField;

    private string variationsField;

    private Defaults defaultsField;

    private string valuesField;

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
    public Characteristic characteristic_descriptor
    {
      get
      {
        return this.characteristic_descriptorField;
      }
      set
      {
        this.characteristic_descriptorField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    public string storage
    {
      get
      {
        return this.storageField;
      }
      set
      {
        this.storageField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    public string variations
    {
      get
      {
        return this.variationsField;
      }
      set
      {
        this.variationsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    public Defaults defaults
    {
      get
      {
        return this.defaultsField;
      }
      set
      {
        this.defaultsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
    public string values
    {
      get
      {
        return this.valuesField;
      }
      set
      {
        this.valuesField = value;
      }
    }
  }

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "https://example.org/ROOTMAP/SharedAttributesSchema")]
  public partial class Characteristic
  {

    private double minimumField;

    private double maximumField;

    private double defaultField;

    private string nameField;

    private string unitsField;

    private bool visibleField;

    private bool editableField;

    private bool tobesavedField;

    private bool specialperboxinfoField;

    private bool specialperboxinfoFieldSpecified;

    private string stratumField;

    /// <remarks/>
    public double minimum
    {
      get
      {
        return this.minimumField;
      }
      set
      {
        this.minimumField = value;
      }
    }

    /// <remarks/>
    public double maximum
    {
      get
      {
        return this.maximumField;
      }
      set
      {
        this.maximumField = value;
      }
    }

    /// <remarks/>
    public double @default
    {
      get
      {
        return this.defaultField;
      }
      set
      {
        this.defaultField = value;
      }
    }

    /// <remarks/>
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
    public string units
    {
      get
      {
        return this.unitsField;
      }
      set
      {
        this.unitsField = value;
      }
    }

    /// <remarks/>
    public bool visible
    {
      get
      {
        return this.visibleField;
      }
      set
      {
        this.visibleField = value;
      }
    }

    /// <remarks/>
    public bool editable
    {
      get
      {
        return this.editableField;
      }
      set
      {
        this.editableField = value;
      }
    }

    /// <remarks/>
    public bool tobesaved
    {
      get
      {
        return this.tobesavedField;
      }
      set
      {
        this.tobesavedField = value;
      }
    }

    /// <remarks/>
    public bool specialperboxinfo
    {
      get
      {
        return this.specialperboxinfoField;
      }
      set
      {
        this.specialperboxinfoField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool specialperboxinfoSpecified
    {
      get
      {
        return this.specialperboxinfoFieldSpecified;
      }
      set
      {
        this.specialperboxinfoFieldSpecified = value;
      }
    }

    /// <remarks/>
    public string stratum
    {
      get
      {
        return this.stratumField;
      }
      set
      {
        this.stratumField = value;
      }
    }
  }

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "https://example.org/ROOTMAP/SharedAttributesSchema")]
  public partial class Defaults
  {

    private string variation_nameField;

    private string valuesField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public string variation_name
    {
      get
      {
        return this.variation_nameField;
      }
      set
      {
        this.variation_nameField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    public string values
    {
      get
      {
        return this.valuesField;
      }
      set
      {
        this.valuesField = value;
      }
    }
  }
}

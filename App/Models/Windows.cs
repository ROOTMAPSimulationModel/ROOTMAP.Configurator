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
namespace Rootmap.Configurator.Schema.Windows
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

    private Visualisation[] visualisationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("visualisation", Order = 0)]
    public Visualisation[] visualisation
    {
      get
      {
        return this.visualisationField;
      }
      set
      {
        this.visualisationField = value;
      }
    }
  }

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "https://example.org/ROOTMAP/ViewSchema")]
  public partial class Visualisation
  {

    private ViewOwner ownerField;

    private object itemField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public ViewOwner owner
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
    [System.Xml.Serialization.XmlElementAttribute("table", typeof(Table), Order = 1)]
    [System.Xml.Serialization.XmlElementAttribute("view", typeof(View), Order = 1)]
    [System.Xml.Serialization.XmlElementAttribute("view3d", typeof(View3D), Order = 1)]
    public object Item
    {
      get
      {
        return this.itemField;
      }
      set
      {
        this.itemField = value;
      }
    }
  }

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "https://example.org/ROOTMAP/ViewSchema")]
  public enum ViewOwner
  {

    /// <remarks/>
    TableCoordinator,

    /// <remarks/>
    ViewCoordinator,

    /// <remarks/>
    View3DCoordinator,
  }

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "https://example.org/ROOTMAP/ViewSchema")]
  public partial class Table
  {

    private string process_nameField;

    private string characteristic_nameField;

    private ViewDirection view_directionField;

    private int layer_numberField;

    private string stratumField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
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

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    public ViewDirection view_direction
    {
      get
      {
        return this.view_directionField;
      }
      set
      {
        this.view_directionField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    public int layer_number
    {
      get
      {
        return this.layer_numberField;
      }
      set
      {
        this.layer_numberField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
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

  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "https://example.org/ROOTMAP/ViewSchema")]
  public enum ViewDirection
  {

    /// <remarks/>
    Front,

    /// <remarks/>
    Top,

    /// <remarks/>
    Side,
  }

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "https://example.org/ROOTMAP/ViewSchema")]
  public partial class View3D
  {

    private string view_positionField;

    private decimal scaleField;

    private bool boundariesField;

    private bool boxesField;

    private bool box_coloursField;

    private decimal root_radius_multiplierField;

    private bool root_colour_by_branch_orderField;

    private bool high_contrast_root_colourField;

    private decimal base_root_redField;

    private decimal base_root_greenField;

    private decimal base_root_blueField;

    private View3DQuality qualityField;

    private string scoreboardsField;

    private string processesField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public string view_position
    {
      get
      {
        return this.view_positionField;
      }
      set
      {
        this.view_positionField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    public decimal scale
    {
      get
      {
        return this.scaleField;
      }
      set
      {
        this.scaleField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    public bool boundaries
    {
      get
      {
        return this.boundariesField;
      }
      set
      {
        this.boundariesField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    public bool boxes
    {
      get
      {
        return this.boxesField;
      }
      set
      {
        this.boxesField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    public bool box_colours
    {
      get
      {
        return this.box_coloursField;
      }
      set
      {
        this.box_coloursField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
    public decimal root_radius_multiplier
    {
      get
      {
        return this.root_radius_multiplierField;
      }
      set
      {
        this.root_radius_multiplierField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
    public bool root_colour_by_branch_order
    {
      get
      {
        return this.root_colour_by_branch_orderField;
      }
      set
      {
        this.root_colour_by_branch_orderField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
    public bool high_contrast_root_colour
    {
      get
      {
        return this.high_contrast_root_colourField;
      }
      set
      {
        this.high_contrast_root_colourField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
    public decimal base_root_red
    {
      get
      {
        return this.base_root_redField;
      }
      set
      {
        this.base_root_redField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
    public decimal base_root_green
    {
      get
      {
        return this.base_root_greenField;
      }
      set
      {
        this.base_root_greenField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
    public decimal base_root_blue
    {
      get
      {
        return this.base_root_blueField;
      }
      set
      {
        this.base_root_blueField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
    public View3DQuality quality
    {
      get
      {
        return this.qualityField;
      }
      set
      {
        this.qualityField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
    public string scoreboards
    {
      get
      {
        return this.scoreboardsField;
      }
      set
      {
        this.scoreboardsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
    public string processes
    {
      get
      {
        return this.processesField;
      }
      set
      {
        this.processesField = value;
      }
    }
  }

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://example.org/ROOTMAP/ViewSchema")]
  public enum View3DQuality
  {

    /// <remarks/>
    low,

    /// <remarks/>
    medium,

    /// <remarks/>
    high,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("very high")]
    veryhigh,
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

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "https://example.org/ROOTMAP/ViewSchema")]
  public partial class Characteristics
  {

    private CharacteristicColourInfo cyanField;

    private CharacteristicColourInfo magentaField;

    private CharacteristicColourInfo yellowField;

    /// <remarks/>
    public CharacteristicColourInfo cyan
    {
      get
      {
        return this.cyanField;
      }
      set
      {
        this.cyanField = value;
      }
    }

    /// <remarks/>
    public CharacteristicColourInfo magenta
    {
      get
      {
        return this.magentaField;
      }
      set
      {
        this.magentaField = value;
      }
    }

    /// <remarks/>
    public CharacteristicColourInfo yellow
    {
      get
      {
        return this.yellowField;
      }
      set
      {
        this.yellowField = value;
      }
    }
  }

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2046.0")]

  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "https://example.org/ROOTMAP/ViewSchema")]
  public partial class View
  {

    private ViewDirection view_directionField;

    private string reference_indexField;

    private decimal scaleField;

    private decimal zoom_ratioField;

    private bool repeatField;

    private bool wrapField;

    private bool boundariesField;

    private bool boxesField;

    private bool box_coloursField;

    private string scoreboardsField;

    private string processesField;

    private Characteristics characteristicsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public ViewDirection view_direction
    {
      get
      {
        return this.view_directionField;
      }
      set
      {
        this.view_directionField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    public string reference_index
    {
      get
      {
        return this.reference_indexField;
      }
      set
      {
        this.reference_indexField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    public decimal scale
    {
      get
      {
        return this.scaleField;
      }
      set
      {
        this.scaleField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    public decimal zoom_ratio
    {
      get
      {
        return this.zoom_ratioField;
      }
      set
      {
        this.zoom_ratioField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    public bool repeat
    {
      get
      {
        return this.repeatField;
      }
      set
      {
        this.repeatField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
    public bool wrap
    {
      get
      {
        return this.wrapField;
      }
      set
      {
        this.wrapField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
    public bool boundaries
    {
      get
      {
        return this.boundariesField;
      }
      set
      {
        this.boundariesField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
    public bool boxes
    {
      get
      {
        return this.boxesField;
      }
      set
      {
        this.boxesField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
    public bool box_colours
    {
      get
      {
        return this.box_coloursField;
      }
      set
      {
        this.box_coloursField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
    public string scoreboards
    {
      get
      {
        return this.scoreboardsField;
      }
      set
      {
        this.scoreboardsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
    public string processes
    {
      get
      {
        return this.processesField;
      }
      set
      {
        this.processesField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
    public Characteristics characteristics
    {
      get
      {
        return this.characteristicsField;
      }
      set
      {
        this.characteristicsField = value;
      }
    }
  }
}

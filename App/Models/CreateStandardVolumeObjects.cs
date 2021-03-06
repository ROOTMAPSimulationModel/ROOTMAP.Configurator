namespace Rootmap.Configurator.Schema
{
  public sealed class CreateStandardVolumeObjects : ICreate, ICreateStandard<VolumeObjects.rootmap>
  {
    private const string content = @"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>
<!-- VolumeObject specification file                                        -->
<!--                                                                        -->
<!-- CURRENTLY SUPPORTED CLASSES:                                           -->
<!--                                                                        -->
<!-- BoundingCylinder                                                       -->
<!-- Specifies a cylinder of a given depth,                                 -->
<!-- the top disc centred at the coordinate <origin>.                       -->
<!-- BoundingCylinders have impenetrable surfaces and do not affect         -->
<!-- the growth rate of root tips growing within them.                      -->
<!--                                                                        -->
<!-- BoundingRectangularPrism                                               -->
<!-- Specifies a right cuboid defined by two points, the left front top     -->
<!-- and right back bottom coordinates. Aligned with the Z-axis             -->
<!-- in the same way as BoundingCylinders.                                  -->
<!-- BoundingRectangularPrisms have impenetrable surfaces and do not affect -->
<!-- the growth rate of root tips growing within them.                      -->
<!--                                                                        -->

<rootmap
    xmlns=""https://example.org/ROOTMAP/VolumeObjectsSchema""
    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
    xsi:schemaLocation=""https://example.org/ROOTMAP/VolumeObjectsSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/VolumeObjects.xsd"">
    <construction>
        <owner>VolumeObjectCoordinator</owner>
        <volumeobject>
            <class_name>BoundingCylinder</class_name>
            <root_penetration_probability>
                <top>1.0</top>
                <bottom>0.0</bottom>
                <sides>0.0</sides>
                <probability_calculation_algorithm>Directly Specified</probability_calculation_algorithm>
            </root_penetration_probability>
            <permeability>
                <top>0.0</top>
                <bottom>0.0</bottom>
                <sides>0.0</sides>
            </permeability>
            <origin>8,8,0.1</origin>
            <depth>40.0</depth>
            <radius>7</radius>
        </volumeobject>

        <!-- <volumeobject> -->
            <!-- <class_name>BoundingCylinder</class_name> -->
            <!-- <root_penetration_probability> -->
                <!-- <top>1.0</top> -->
                <!-- <bottom>1.0</bottom> -->
                <!-- <sides>0.0</sides> -->
                <!-- <probability_calculation_algorithm>Directly Specified</probability_calculation_algorithm> -->
            <!-- </root_penetration_probability> -->
            <!-- <permeability> -->
                <!-- <top>0.0</top> -->
                <!-- <bottom>0.0</bottom> -->
                <!-- <sides>0.0</sides> -->
            <!-- </permeability> -->
            <!-- <origin>5,5,70</origin> -->
            <!-- <depth>5.0</depth> -->
            <!-- <radius>4</radius> -->
        <!-- </volumeobject> -->

        <!-- <volumeobject> -->
            <!-- <class_name>BoundingRectangularPrism</class_name> -->
            <!-- <leftfronttop>0,0,0</leftfronttop> -->
            <!-- <rightbackbottom>1,11,50</rightbackbottom> -->
        <!-- </volumeobject> -->
        <!-- <volumeobject> -->
            <!-- <class_name>BoundingRectangularPrism</class_name> -->
            <!-- <leftfronttop>1,0,0</leftfronttop> -->
            <!-- <rightbackbottom>11,1,50</rightbackbottom> -->
        <!-- </volumeobject> -->
        <!-- <volumeobject> -->
            <!-- <class_name>BoundingRectangularPrism</class_name> -->
            <!-- <leftfronttop>10,1,0</leftfronttop> -->
            <!-- <rightbackbottom>11,11,50</rightbackbottom> -->
        <!-- </volumeobject> -->
        <!-- <volumeobject> -->
            <!-- <class_name>BoundingRectangularPrism</class_name> -->
            <!-- <leftfronttop>1,10,0</leftfronttop> -->
            <!-- <rightbackbottom>10,11,50</rightbackbottom> -->
        <!-- </volumeobject>   -->
    </construction>
</rootmap>
";
    public dynamic Create(ILoader loader)
    {
      return loader.Deserialise(content);
    }
  }
}

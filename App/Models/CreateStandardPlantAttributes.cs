﻿namespace Rootmap.Configurator.Schema
{
  public sealed class CreateStandardPlantAttributes : ICreate, ICreateStandard<SharedAttributes.rootmap>
  {
    private const string content = @"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>
<rootmap
    xmlns=""https://example.org/ROOTMAP/SharedAttributesSchema""
    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
    xsi:schemaLocation=""https://example.org/ROOTMAP/SharedAttributesSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/SharedAttributes.xsd"">
    <construction>
        <owner>SharedAttributeManager</owner>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Seminal Branch Lag Time</name>
                <units>hours</units>
                <minimum>0.0</minimum>
                <maximum>INF</maximum>
                <default>96.0</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
            <defaults>
                <variation_name>RootOrder</variation_name>
                <values>72.0,240.0,1200.0,3000.0</values>
            </defaults>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Nodal Branch Lag Time</name>
                <units>hours</units>
                <minimum>0.0</minimum>
                <maximum>INF</maximum>
                <default>96.0</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
            <defaults>
                <variation_name>RootOrder</variation_name>
                <values>50.0,80.0,96.0,3000.0</values>
            </defaults>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Seminal Deflection Index</name>
                <units>-</units>
                <minimum>0.0</minimum>
                <maximum>1.0</maximum>
                <default>0.3</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
            <defaults>
                <variation_name>RootOrder</variation_name>
                <values>0.25,0.2,0.2,0.2</values>
            </defaults>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Nodal Deflection Index</name>
                <units>-</units>
                <minimum>0.0</minimum>
                <maximum>1.0</maximum>
                <default>0.3</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
            <defaults>
                <variation_name>RootOrder</variation_name>
                <values>0.4,0.4,0.3,0.25</values>
            </defaults>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Seminal Final Branch Interval</name>
                <units>cm</units>
                <minimum>0.0</minimum>
                <maximum>10.0</maximum>
                <default>0.27</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
            <defaults>
                <variation_name>RootOrder</variation_name>
                <values>0.52,0.52,0.8,0.4</values>
            </defaults>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Nodal Final Branch Interval</name>
                <units>cm</units>
                <minimum>0.0</minimum>
                <maximum>10.0</maximum>
                <default>0.5</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
            <defaults>
                <variation_name>RootOrder</variation_name>
                <values>2.0,0.5,0.8,0.4</values>
            </defaults>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Seminal Geotropism Index</name>
                <units>-</units>
                <minimum>0.0</minimum>
                <maximum>1.0</maximum>
                <default>0.8</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
            <defaults>
                <variation_name>RootOrder</variation_name>
                <values>0.75,0.25,0.1,0.1</values>
            </defaults>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Nodal Geotropism Index</name>
                <units>-</units>
                <minimum>0.0</minimum>
                <maximum>1.0</maximum>
                <default>0.8</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
            <defaults>
                <variation_name>RootOrder</variation_name>
                <values>0.5,0.2,0.0,0.0</values>
            </defaults>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Growth Rate Max</name>
                <units>cm/hour</units>
                <minimum>0.0</minimum>
                <maximum>10.0</maximum>
                <default>0.04</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
            <defaults>
                <variation_name>RootOrder</variation_name>
                <values>0.1,0.03,0.01,0.01</values>
            </defaults>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Seminal Growth Rate</name>
                <units>cm/hour</units>
                <minimum>0.0</minimum>
                <maximum>10.0</maximum>
                <default>0.04</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
            <defaults>
                <variation_name>RootOrder</variation_name>
                <values>0.08,0.08,0.02,0.01</values>
            </defaults>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Nodal Growth Rate</name>
                <units>cm/hour</units>
                <minimum>0.0</minimum>
                <maximum>10.0</maximum>
                <default>0.04</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
            <defaults>
                <variation_name>RootOrder</variation_name>
                <values>0.08,0.1,0.08,0.08</values>
            </defaults>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Seminal Unit Growth Rate</name>
                <units>none</units>
                <minimum>0.0</minimum>
                <maximum>50000.0</maximum>
                <default>5000.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
            <defaults>
                <variation_name>RootOrder</variation_name>
                <values>40000,2800,1000,2250</values>
            </defaults>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Nodal Unit Growth Rate</name>
                <units>none</units>
                <minimum>0.0</minimum>
                <maximum>50000.0</maximum>
                <default>5000.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
            <defaults>
                <variation_name>RootOrder</variation_name>
                <values>4000,13500,4200,1500</values>
            </defaults>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Initial Branch Angle</name>
                <units>&#xB0;</units>
                <minimum>0.0</minimum>
                <maximum>180.0</maximum>
                <default>90.0</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Initial Branch Interval</name>
                <units>cm</units>
                <minimum>0.0</minimum>
                <maximum>100.0</maximum>
                <default>0.0</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Root Conductance</name>
                <units>-</units>
                <minimum>0.0</minimum>
                <maximum>1.0</maximum>
                <default>1.0</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Tip Growth Duration</name>
                <units>hours</units>
                <minimum>0.0</minimum>
                <maximum>INF</maximum>
                <default>6000.0</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
            <defaults>
                <variation_name>RootOrder</variation_name>
                <values>6000,3120,572.0,1776</values>
            </defaults>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Initial Seminal Deflection</name>
                <units>&#xB0;</units>
                <minimum>0.0</minimum>
                <maximum>90.0</maximum>
                <default>0.0</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>PlantType</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <!-- germination occurs x hours after seed is sown -->
                <name>Germination Lag</name>
                <units>hours</units>
                <minimum>0.0</minimum>
                <maximum>INF</maximum>
                <default>0.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
            <values>23.0,26.0</values>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>First Seminal Probability</name>
                <units>-</units>
                <minimum>0.0</minimum>
                <maximum>1.0</maximum>
                <default>1.0</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>PlantType</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Temperature of Zero Growth</name>
                <units>&#xB0;</units>
                <minimum>-INF</minimum>
                <maximum>INF</maximum>
                <default>0.0</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>PlantType</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Root Radius</name>
                <units>cm</units>
                <minimum>0.01</minimum>
                <maximum>5.0</maximum>
                <default>1.0</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
            <defaults>
                <variation_name>RootOrder</variation_name>
                <values>0.077,0.037,0.028,0.027</values>
            </defaults>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Root Hair Radius</name>
                <units>cm</units>
                <minimum>10.0e-6</minimum>
                <maximum>0.1</maximum>
                <default>60.0e-6</default>
                <visible>true</visible>
                <editable>true</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Root Hair Length</name>
                <units>cm</units>
                <minimum>0.0</minimum>
                <maximum>1.0</maximum>
                <default>0.0159</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Root Hair Density</name>
                <units>hairs/cm</units>
                <minimum>0.0</minimum>
                <maximum>150.0</maximum>
                <default>54.3</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Model Root Hairs</name>
                <!-- 1.0 = yes, 0.0 = no -->
                <units>NONE</units>
                <minimum>0.0</minimum>
                <maximum>1.0</maximum>
                <default>1.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Degree Days Model</name>
                <units>none</units>
                <minimum>0.0</minimum>
                <maximum>1.0</maximum>
                <default>0.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <!-- days after germination that full cover occurs -->
                <name>Full Cover Days</name>
                <units>days</units>
                <minimum>0.0</minimum>
                <maximum>400</maximum>
                <default>100.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <!-- days after germination that ripening occurs -->
                <name>Ripening Days</name>
                <units>days</units>
                <minimum>0.0</minimum>
                <maximum>400</maximum>
                <default>200.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <!-- days after germination that harvest occurs -->
                <name>Harvest Days</name>
                <units>days</units>
                <minimum>0.0</minimum>
                <maximum>400</maximum>
                <default>280.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <!-- degree days after germination that full cover occurs -->
                <name>Full Cover Degree Days</name>
                <units>degreeC</units>
                <minimum>0.0</minimum>
                <maximum>2000</maximum>
                <default>0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <!-- degree days after germination that full cover occurs -->
                <name>Ripening Degree Days</name>
                <units>days</units>
                <minimum>0.0</minimum>
                <maximum>2000</maximum>
                <default>0.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <!-- degree days after germination that full cover occurs -->
                <name>Harvest Degree Days</name>
                <units>days</units>
                <minimum>0.0</minimum>
                <maximum>2000</maximum>
                <default>0.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>true</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Ground Cover Max</name>
                <units>-</units>
                <minimum>0.0</minimum>
                <maximum>1.0</maximum>
                <default>1.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Ground Cover Harvest</name>
                <units>-</units>
                <minimum>0.0</minimum>
                <maximum>1.0</maximum>
                <default>0.5</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Previous Total Root Length</name>
                <units>cm</units>
                <minimum>0.0</minimum>
                <maximum>1e+7</maximum>
                <default>0.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Plant Is Legume</name>
                <units>none</units>
                <minimum>0</minimum>
                <maximum>1</maximum>
                <default>1</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Degree Days Base Temp</name>
                <units>degreeC</units>
                <minimum>0</minimum>
                <maximum>10</maximum>
                <default>0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Seeding Time</name>
                <units>hours</units>
                <minimum>0</minimum>
                <maximum>4000</maximum>
                <default>0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Imax Decline Curve</name>
                <units>none</units>
                <minimum>0</minimum>
                <maximum>1</maximum>
                <default>0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Root P Plasticity Factor</name>
                <units>none</units>
                <minimum>1.0</minimum>
                <maximum>3</maximum>
                <default>1.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Down Regulation Factor</name>
                <units>none</units>
                <minimum>0.0</minimum>
                <maximum>1.0</maximum>
                <default>1.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant,RootOrder</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Root N Plasticity Factor</name>
                <units>none</units>
                <minimum>1.0</minimum>
                <maximum>3</maximum>
                <default>1.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>Scoreboard</storage>
            <variations>Plant,RootOrder,VolumeObject</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>N Regulation Factor</name>
                <units>none</units>
                <minimum>0.0</minimum>
                <maximum>1.0</maximum>
                <default>1.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>P Regulation Factor</name>
                <units>none</units>
                <minimum>0.0</minimum>
                <maximum>1.0</maximum>
                <default>1.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Remaining N Resource Units</name>
                <units>none</units>
                <minimum>0.0</minimum>
                <maximum>1e+10</maximum>
                <default>0.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Remaining P Resource Units</name>
                <units>none</units>
                <minimum>0.0</minimum>
                <maximum>1e+10</maximum>
                <default>0.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Plant Target Resource Ratio</name>
                <units>none</units>
                <minimum>0.0</minimum>
                <maximum>500</maximum>
                <!-- target raio of N:P resources in the plant tissue lupin = 15.0 -->
                <default>15.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Plant Actual Resource Ratio</name>
                <units>none</units>
                <minimum>0.0</minimum>
                <maximum>10</maximum>
                <default>1.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Mean Coty Life</name>
                <!-- average number of days that the plant cotyledons are supplying the seedling with resources -->
                <units>days</units>
                <minimum>0.0</minimum>
                <maximum>100</maximum>
                <default>7.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Leaf Emergence</name>
                <!-- time in days from germination for the 1st true leaf to emerge -->
                <units>days</units>
                <minimum>0.0</minimum>
                <maximum>100</maximum>
                <default>8.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Nutrient Solution</name>
                <!-- 1.0 = Nutrient solution experiment, 0.0 = soil experiment -->
                <units>NONE</units>
                <minimum>0.0</minimum>
                <maximum>1.0</maximum>
                <default>0.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Nutrient Solution Renew</name>
                <!-- time in days between solution changes -->
                <units>days</units>
                <minimum>0.0</minimum>
                <maximum>1000</maximum>
                <default>0.01</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
        <attribute>
            <owner>PlantCoordinator</owner>
            <characteristic_descriptor>
                <name>Nutrient Renew</name>
                <!-- time in days between addition of nutrient solution to free draining sandy soil -->
                <units>days</units>
                <minimum>0.0</minimum>
                <maximum>1000</maximum>
                <default>3.0</default>
                <visible>false</visible>
                <editable>false</editable>
                <tobesaved>false</tobesaved>
                <stratum>Soil</stratum>
            </characteristic_descriptor>
            <storage>PlantCoordinator</storage>
            <variations>Plant</variations>
        </attribute>
    </construction>
</rootmap>
";

    public dynamic Create(ILoader loader)
    {
      return loader.Deserialise(content);
    }
  }
}

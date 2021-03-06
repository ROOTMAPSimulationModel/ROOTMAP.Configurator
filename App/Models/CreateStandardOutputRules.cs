namespace Rootmap.Configurator.Schema
{
  public sealed class CreateStandardOutputRules : ICreate, ICreateStandard<OutputRules.rootmap>
  {
    private const string content = @"<?xml version=""1.0"" encoding=""utf-8""?>

<rootmap
    xmlns=""https://example.org/ROOTMAP/OutputRulesSchema""
    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
    xsi:schemaLocation=""https://example.org/ROOTMAP/OutputRulesSchema https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/OutputRules.xsd"">

    <initialisation>
        <owner>DataOutputCoordinator</owner>
        <outputrule>
            <type>ScoreboardData</type>
            <source>PlantCoordinator</source>
            <!-- characteristic is meaningful for the type/source combination
           It applies in the general non-scoreboard sense of the term
           also, you see -->
            <characteristic>Root Length Wrap None Plant 1</characteristic>
            <stratum>Soil</stratum>
            <!-- accepts % formatting codes for strftime -->
            <!-- Pre-processes URL % formatted values before passing to strftime
           eg. use %20 for trailing spaces -->
            <!-- Pre-processes extra format specifiers:
           %C counter for number of outputs for this object so far (UNSUPPORTED)
           %R raw timestamp in seconds from T=0 (UNSUPPORTED)
           both of these accept the usual %d format specifiers,
           eg. ""%.3C"" produces a 3-digit leading-zero-padded.
           The following example produces a filename like
           RootLength_YYYYmmdd-HHMMSS.txt
           PLEASE ensure you don't confuse the lowercase and uppercase 'm'.
           m=month, M=Minute -->
            <filename>RootLengthPlant1.txt</filename>
            <!-- specification1 and specification2 are meaningful to the type.
           For ""ScoreboardData"", specification1 is the dimension order. -->
            <specification1>X,Z,Y</specification1>
            <!-- how to handle current contents when opening a non-empty file:
           append|overwrite (default=overwrite) -->
            <reopen>append</reopen>
            <when>
                <!-- a count of zero is to repeat ad infinitum -->
                <count>0</count>
                <!-- For exporting ""every"" so often, use the initialtime and frequency tags
             Year,Month,Day,Hour,Minute,Second -->
                <initialtime>0,0,0,0,0,0</initialtime>
                <interval>0,0,0,1,0,0</interval>
            </when>
        </outputrule>
        <outputrule>
            <type>ScoreboardData</type>
            <source>PlantCoordinator</source>
            <!-- characteristic is meaningful for the type/source combination
           It applies in the general non-scoreboard sense of the term
           also, you see -->
            <characteristic>Root Length Wrap None Plant 2</characteristic>
            <stratum>Soil</stratum>
            <!-- accepts % formatting codes for strftime -->
            <!-- Pre-processes URL % formatted values before passing to strftime
           eg. use %20 for trailing spaces -->
            <!-- Pre-processes extra format specifiers:
           %C counter for number of outputs for this object so far (UNSUPPORTED)
           %R raw timestamp in seconds from T=0 (UNSUPPORTED)
           both of these accept the usual %d format specifiers,
           eg. ""%.3C"" produces a 3-digit leading-zero-padded.
           The following example produces a filename like
           RootLength_YYYYmmdd-HHMMSS.txt
           PLEASE ensure you don't confuse the lowercase and uppercase 'm'.
           m=month, M=Minute -->
            <filename>RootLengthPlant2.txt</filename>
            <!-- specification1 and specification2 are meaningful to the type.
           For ""ScoreboardData"", specification1 is the dimension order. -->
            <specification1>X,Z,Y</specification1>
            <!-- how to handle current contents when opening a non-empty file:
           append|overwrite (default=overwrite) -->
            <reopen>append</reopen>
            <when>
                <!-- a count of zero is to repeat ad infinitum -->
                <count>0</count>
                <!-- For exporting ""every"" so often, use the initialtime and frequency tags
             Year,Month,Day,Hour,Minute,Second
				TODO: this comment contradicts the code-->
                <initialtime>0,0,0,0,0,0</initialtime>
                <interval>0,0,0,1,0,0</interval>
            </when>
        </outputrule>
		<outputrule>
		  <type>ScoreboardData</type>
		  <source>PlantCoordinator</source>
		  <!-- characteristic is meaningful for the type/source combination
			   It applies in the general non-scoreboard sense of the term
			   also, you see -->
		  <characteristic>Tip Count Wrap None Plant 1 RootOrder1</characteristic>
		  <stratum>Soil</stratum>
		  <!-- accepts % formatting codes for strftime -->
		  <!-- Pre-processes URL % formatted values before passing to strftime
			   eg. use %20 for trailing spaces -->
		  <!-- Pre-processes extra format specifiers:
			   %C counter for number of outputs for this object so far (UNSUPPORTED)
			   %R raw timestamp in seconds from T=0 (UNSUPPORTED)
			   both of these accept the usual %d format specifiers,
			   eg. ""%.3C"" produces a 3-digit leading-zero-padded.
			   The following example produces a filename like
			   RootLength_YYYYmmdd-HHMMSS.txt
			   PLEASE ensure you don't confuse the lowercase and uppercase 'm'.
			   m=month, M=Minute -->
		  <filename>TipCount1.txt</filename>
		  <!-- specification1 and specification2 are meaningful to the type.
			   For ""ScoreboardData"", specification1 is the dimension order. -->
		  <specification1>X,Z,Y</specification1>
		  <!-- how to handle current contents when openning a non-empty file:
			   append|overwrite (default=overwrite) -->
		  <reopen>append</reopen>
		  <when>
			<!-- a count of zero is to repeat ad infinitum -->
			<count>0</count>
			<!-- For exporting ""every"" so often, use the initialtime and frequency tags
				 Year,Month,Day,Hour,Minute,Second -->
			<initialtime>0,0,0,0,0,0</initialtime>
			<interval>0,0,0,1,0,0</interval>
		  </when>
		</outputrule>
		<outputrule>
		  <type>ScoreboardData</type>
		  <source>PlantCoordinator</source>
		  <!-- characteristic is meaningful for the type/source combination
			   It applies in the general non-scoreboard sense of the term
			   also, you see -->
		  <characteristic>Tip Count Wrap None Plant 2 RootOrder1</characteristic>
		  <stratum>Soil</stratum>
		  <!-- accepts % formatting codes for strftime -->
		  <!-- Pre-processes URL % formatted values before passing to strftime
			   eg. use %20 for trailing spaces -->
		  <!-- Pre-processes extra format specifiers:
			   %C counter for number of outputs for this object so far (UNSUPPORTED)
			   %R raw timestamp in seconds from T=0 (UNSUPPORTED)
			   both of these accept the usual %d format specifiers,
			   eg. ""%.3C"" produces a 3-digit leading-zero-padded.
			   The following example produces a filename like
			   RootLength_YYYYmmdd-HHMMSS.txt
			   PLEASE ensure you don't confuse the lowercase and uppercase 'm'.
			   m=month, M=Minute -->
		  <filename>TipCount2.txt</filename>
		  <!-- specification1 and specification2 are meaningful to the type.
			   For ""ScoreboardData"", specification1 is the dimension order. -->
		  <specification1>X,Z,Y</specification1>
		  <!-- how to handle current contents when openning a non-empty file:
			   append|overwrite (default=overwrite) -->
		  <reopen>append</reopen>
		  <when>
			<!-- a count of zero is to repeat ad infinitum -->
			<count>0</count>
			<!-- For exporting ""every"" so often, use the initialtime and frequency tags
				 Year,Month,Day,Hour,Minute,Second -->
			<initialtime>0,0,0,0,0,0</initialtime>
			<interval>0,0,0,1,0,0</interval>
		  </when>
		</outputrule>
    </initialisation>

  <initialisation>
    <owner>DataOutputCoordinator</owner>
    <outputrule>
      <source>Nitrate</source>
      <type>NonSpatialData</type>
      <characteristic>Cumul Plant Nitrate Uptake</characteristic>
      <stratum>Soil</stratum>
      <!-- Use a filename without any strftime % formatting codes -->
      <!-- and <reopen>append</reopen> to write all data to one file, -->
      <!-- suitable for graphing -->
      <filename>CumulNUptake.csv</filename>
      <!-- <specification1> is the variation name(s), e.g. ""Plant"" - see files in ./shared_attributes/ -->
      <specification1>Plant,RootOrder</specification1>
      <!-- 	<specification2>n</specification2> specifies a data dimensionality of n, where 0<=n<=2.
			Use <type>ScoreboardData</type> for data that is spatially relevant.	-->
      <specification2>csv</specification2>
      <reopen>append</reopen>
      <when>
        <!-- a count of zero is to repeat ad infinitum -->
        <count>0</count>
        <!-- For exporting ""every"" so often, use the initialtime and frequency tags
			 Year,Month,Day,Hour,Minute,Second -->
        <interval>0,0,0,0,0,0</interval>
        <initialtime>0,0,0,1,0,0</initialtime>
      </when>
    </outputrule>
    <outputrule>
      <source>Nitrate</source>
      <type>NonSpatialData</type>
      <characteristic>Cumul Plant N Fixation</characteristic>
      <stratum>Soil</stratum>
      <!-- Use a filename without any strftime % formatting codes -->
      <!-- and <reopen>append</reopen> to write all data to one file, -->
      <!-- suitable for graphing -->
      <filename>CumulNFix.csv</filename>
      <!-- <specification1> is the variation name(s), e.g. ""Plant"" - see files in ./shared_attributes/ -->
      <specification1>Plant,RootOrder</specification1>
      <!-- 	<specification2>n</specification2> specifies a data dimensionality of n, where 0<=n<=2.
			Use <type>ScoreboardData</type> for data that is spatially relevant.	-->
      <specification2>csv</specification2>
      <reopen>append</reopen>
      <when>
        <!-- a count of zero is to repeat ad infinitum -->
        <count>0</count>
        <!-- For exporting ""every"" so often, use the initialtime and frequency tags
			 Year,Month,Day,Hour,Minute,Second -->
        <interval>0,0,0,0,0,0</interval>
        <initialtime>0,0,0,1,0,0</initialtime>
      </when>
    </outputrule>
    <outputrule>
      <source>Nitrate</source>
      <type>NonSpatialData</type>
      <characteristic>Cumulative Phosphorus Uptake</characteristic>
      <stratum>Soil</stratum>
      <!-- Use a filename without any strftime % formatting codes -->
      <!-- and <reopen>append</reopen> to write all data to one file, -->
      <!-- suitable for graphing -->
      <filename>CumulPUptake.csv</filename>
      <!-- <specification1> is the variation name(s), e.g. ""Plant"" - see files in ./shared_attributes/ -->
      <specification1>Plant,RootOrder</specification1>
      <!-- 	<specification2>n</specification2> specifies a data dimensionality of n, where 0<=n<=2.
			Use <type>ScoreboardData</type> for data that is spatially relevant.	-->
      <specification2>csv</specification2>
      <reopen>append</reopen>
      <when>
        <!-- a count of zero is to repeat ad infinitum -->
        <count>0</count>
        <!-- For exporting ""every"" so often, use the initialtime and frequency tags
			 Year,Month,Day,Hour,Minute,Second -->
        <interval>0,0,0,0,0,0</interval>
        <initialtime>0,0,0,1,0,0</initialtime>
      </when>
    </outputrule>
  </initialisation>
</rootmap>
";
    public dynamic Create(ILoader loader)
    {
      return loader.Deserialise(content);
    }
  }
}

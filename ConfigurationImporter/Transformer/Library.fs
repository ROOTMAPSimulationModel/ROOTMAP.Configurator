namespace Rootmap.ConfigurationImporter
    open System
    open System.IO
    open System.Text.RegularExpressions

    module ConfigurationTransformer =

        let private schemataContainerUri = Uri("https://rootmapstorageaccount.blob.core.windows.net/rootmap-schemata-container/")

        // This regex matches any <rootmap> tag, with or without attributes.
        let private rootmapElementMatcher = Regex("<rootmap(\s+[^>]*)?>", RegexOptions.Singleline ||| RegexOptions.IgnoreCase)

        // This regex matches obsolete tags.
        let private obsoleteElementMatcher = Regex("<configuration>[\s\r\n]*<name>Engine Initialisation Data</name>[\s\S]*?<location>Engine.xml</location>[\s\r\n]*</configuration>", RegexOptions.IgnoreCase)

        // Data used to match any ROOTMAP configuration file
        // to its appropriate schema.
        // Basically, if the filename contains tuple[0],
        // its assigned schema name is tuple [1]
        // and its relative path to the schema file is tuple[2].
        //
        // TODO: Compute these relative schema paths at runtime
        // given the real absolute directories of each file and the Schemata directory.
        type FilenameSchemaMapping = { filenameFragment: string; schemaName: string; schemaFilename: string }
        let private schemaInfo = [
            // Main directory
            { filenameFragment = "OutputRules"; schemaName = "OutputRulesSchema"; schemaFilename = "OutputRules.xsd"}
            { filenameFragment = "PostOffice"; schemaName = "PostOfficeSchema"; schemaFilename = "PostOffice.xsd"}
            { filenameFragment = "Renderer"; schemaName = "ViewSchema"; schemaFilename = "Renderer.xsd"}
            { filenameFragment = "rootmap"; schemaName = "MainSchema"; schemaFilename = "Main.xsd"}
            { filenameFragment = "Scoreboards"; schemaName = "ScoreboardsSchema"; schemaFilename = "Scoreboards.xsd"}
            { filenameFragment = "VolumeObjects"; schemaName = "VolumeObjectsSchema"; schemaFilename = "VolumeObjects.xsd"}
            { filenameFragment = "Windows"; schemaName = "ViewSchema"; schemaFilename = "Windows.xsd"}
            // ProcessData directory
            { filenameFragment = "Plants"; schemaName = "PlantsSchema"; schemaFilename = "Plants.xsd"}
            { filenameFragment = "PlantTypes"; schemaName = "PlantTypesSchema"; schemaFilename = "PlantTypes.xsd"}
            { filenameFragment = "Processes"; schemaName = "ProcessesSchema"; schemaFilename = "Processes.xsd"}
            { filenameFragment = "RainfallEvents"; schemaName = "RainfallEventsSchema"; schemaFilename = "RainfallEvents.xsd"}
            // ScoreboardData directory
            { filenameFragment = "BulkDensity"; schemaName = "ScoreboardDataSchema"; schemaFilename = "ScoreboardData.xsd"}
            { filenameFragment = "NitrateAmount"; schemaName = "ScoreboardDataSchema"; schemaFilename = "ScoreboardData.xsd"}
            { filenameFragment = "PenetrometerResistance"; schemaName = "ScoreboardDataSchema"; schemaFilename = "ScoreboardData.xsd"}
            { filenameFragment = "PhosphorusData"; schemaName = "ScoreboardDataSchema"; schemaFilename = "ScoreboardData.xsd"}
            { filenameFragment = "SoilWaterContent"; schemaName = "ScoreboardDataSchema"; schemaFilename = "ScoreboardData.xsd"}
            // SharedAttributes directory
            { filenameFragment = "NitrateAttributes"; schemaName = "SharedAttributesSchema"; schemaFilename = "SharedAttributes.xsd"}
            { filenameFragment = "PhosphorusAttributes"; schemaName = "SharedAttributesSchema"; schemaFilename = "SharedAttributes.xsd"}
            { filenameFragment = "PlantAttributes"; schemaName = "SharedAttributesSchema"; schemaFilename = "SharedAttributes.xsd"}
            { filenameFragment = "WaterAttributes"; schemaName = "SharedAttributesSchema"; schemaFilename = "SharedAttributes.xsd"}
            { filenameFragment = "NitrateAttributeInitialValues"; schemaName = "ScoreboardDataSchema"; schemaFilename = "ScoreboardData.xsd"}
            { filenameFragment = "PhosphorusAttributeInitialValues"; schemaName = "ScoreboardDataSchema"; schemaFilename = "ScoreboardData.xsd"}
            { filenameFragment = "PlantAttributeInitialValues"; schemaName = "ScoreboardDataSchema"; schemaFilename = "ScoreboardData.xsd"}
            { filenameFragment = "WaterAttributeInitialValues"; schemaName = "ScoreboardDataSchema"; schemaFilename = "ScoreboardData.xsd"}
        ]

        type Result<'TEntity> =
            | Success of 'TEntity
            | Failure of string

        let private bind switchFunction =
            fun twoTrackInput ->
                match twoTrackInput with
                | Success s -> switchFunction s
                | Failure f -> Failure f

        let private getSchemaInfo fn =
            try
                List.find (fun x -> Path.GetFileNameWithoutExtension(fn).Contains(x.filenameFragment)) schemaInfo
                |> Success
            with
                | :? Collections.Generic.KeyNotFoundException -> Failure (sprintf "Could not find a matching schema for %s" fn)

        // The relative path is preferred, but we can use the provided absolute path
        // if the relative path does not exist.
        let private resolveBestPath relativeCandidatePath filename absoluteCandidatePath: string =
            if File.Exists(Path.Combine(Path.GetDirectoryName(filename), relativeCandidatePath))
            then relativeCandidatePath
            else absoluteCandidatePath + relativeCandidatePath.Substring(relativeCandidatePath.LastIndexOf("Schemata") + "Schemata".Length)

        let private makeTag schemaName schemaFilename =
            sprintf """<rootmap
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
        xmlns:xsd="http://www.w3.org/2001/XMLSchema"
        xsi:schemaLocation="https://example.org/ROOTMAP/%s %s%s"
        xmlns="https://example.org/ROOTMAP/%s">""" schemaName (schemataContainerUri.ToString()) schemaFilename schemaName

        let private makeSchemaAnnotation filename =
            match getSchemaInfo filename with
            | Success s -> makeTag s.schemaName s.schemaFilename
            | Failure _ -> "<rootmap>"

        let private schemaAnnotationTransform x f = rootmapElementMatcher.Replace(x, makeSchemaAnnotation f)

        let private obsoleteElementRemovalTransform x = obsoleteElementMatcher.Replace(x, "")

        let private getContent fn =
            try
                File.ReadAllText(fn)
                |> Success
            with
            | _ -> Failure (sprintf "Could not read content from %s" fn)

        let private writeContent fn x =
            File.WriteAllText(fn, x)

        let transformFile fn =
            match getContent(fn) with
            | Success s ->
                schemaAnnotationTransform s fn
                |> obsoleteElementRemovalTransform
                |> writeContent fn
                fn, true
            | Failure f -> fn, false

        let transformAllFiles path =
            try
                Directory.EnumerateFiles(path, "*.xml", SearchOption.AllDirectories)
                |> Seq.map (fun x -> transformFile x)
            with
            | e ->
                Console.WriteLine(e)
                Seq.empty

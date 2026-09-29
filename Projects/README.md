# Projects

This directory contains the batch files used to run the D2CSharp conversion and formatting workflow.

## D2CSharp.bat

`D2CSharp.bat` performs the complete regeneration workflow for the test sources.

It executes the following steps in sequence:

1. `ExtractReworked.exe` compares `TestsGenerated` and `TestsWorking`, clears `TestsReworked`, and copies the manually modified test files to `TestsReworked`.
2. `D2CSharp.exe` translates the Delphi test sources and writes the generated C# files to `TestsGenerated`.
3. All generated files are copied from `TestsGenerated` to `TestsWorking`.
4. The previously preserved files from `TestsReworked` are copied back to `TestsWorking`, restoring existing manual corrections.
5. `D2CSharpTests/Formatting/FormatAll.cmd` is called to format the files in `TestsGenerated` and `TestsWorking` consistently.
6. The batch file pauses so that messages from the workflow can be reviewed.

After running `D2CSharp.bat`, the files in `TestsGenerated` and `TestsWorking` should be compared again. Improvements in a newer `D2CSharp.exe` may make some older manual corrections unnecessary, while new translation problems may require additional corrections in `TestsWorking`.

For a detailed explanation of this workflow, see the main repository `README.md`.

## FormatAll.bat

`FormatAll.bat` can be used when the C# test sources should only be reformatted without running the Delphi-to-C# conversion again.

It calls:

```text
..\D2CSharpTests\Formatting\FormatAll.cmd
```

and then pauses so that any output can be reviewed.

The formatting projects use the .NET/Visual Studio tooling configured for this repository. A suitable Visual Studio installation with the required .NET SDK must therefore be available.

This command is useful after manual changes to files in `TestsWorking`, or whenever `TestsGenerated` and `TestsWorking` should be normalized before comparison with a diff tool such as WinMerge.

## Conversion Log

Running the converter creates a log file in this directory, currently named:

```text
D2CSharp_log.txt
```

The log records information from the conversion process, including the files being preprocessed and parsed and diagnostic messages produced during conversion.

The log is a local development artifact and is not intended to be committed to the repository. The repository `.gitignore` therefore excludes files matching:

```text
*_log.txt
```

Diagnostic messages in the log can be useful when investigating conversion problems. In particular, messages about missing files or other processing problems may help identify incomplete MockRTL declarations, missing RTL units, or other issues that require investigation.

## Expected Directory Context

The batch files use relative paths and are intended to be executed from this `Projects` directory within the repository layout.

They expect, in particular:

```text
../bin/
../TestsGenerated/
../TestsWorking/
../TestsReworked/
../D2CSharpTests/Formatting/
```

`D2CSharp.exe` and `ExtractReworked.exe` must therefore be available in the repository's `bin` directory before `D2CSharp.bat` is executed.

# Contributing to the D2CSharp RTL

Contributions to mock sources, generated and manually completed RTL code, directly implemented helper classes, tests, and documentation are welcome.

## Particularly Useful Contributions

Contributions are especially useful in the following areas:

- completing and improving the MockRTL files,
- adding missing declarations, types, and stub functions under `MockRTL/Source`,
- implementing or correcting functions in the D2CSharp RTL,
- extending existing tests,
- adding focused new tests together with the corresponding functional C# implementations,
- documenting small reproducible translation problems,
- improving project documentation.

The MockRTL is primarily maintained and provided by t2t-soft.

Additions, corrections, and improvement proposals from other contributors are explicitly welcome.

## Contributions to the MockRTL

The files under `MockRTL/Source` provide an independently created representation of the Delphi RTL declarations required by D2CSharp and serve as input for conversion.

Many routines intentionally contain no real implementation, but only empty bodies or suitable default return values.

Contributions that complete or improve the required declarations, data types, and stub functions are particularly welcome.

Changes should be made to the Pascal files under `MockRTL/Source`.

The corresponding files under `MockRTL/Converted` are generated automatically from them and should not be maintained manually as the primary source of a change.

## Contributions to the D2CSharp RTL

Improvements and extensions to the actual D2CSharp RTL are welcome.

If a reconstructed RTL function does not yet have a complete C# implementation, or if an existing implementation is incomplete or incorrect, it may be completed or corrected.

Where possible, such changes should be accompanied by an appropriate test.

## New and Extended Tests

New tests are welcome, but they should be added in a focused manner.

It is technically easy to generate very large numbers of new test files. Each additional test may, however, require further development work on the converter or RTL.

A large number of isolated tests without corresponding implementations is therefore not necessarily helpful.

Contributions are preferred when a new test case is accompanied by a functional C# version or by the RTL implementation required for that test.

New tests should cover a clearly defined language or RTL aspect where possible and should follow the test conventions described in `README.md`.

If automatic translation is not yet correct, a corrected version under `TestsWorking` can demonstrate the intended result.

## Changes to the Converter

The source code of `D2CSharp.exe` is not part of this repository.

Changes to the converter itself therefore cannot be submitted as ordinary repository contributions and are made by t2t-soft.

If a problem is likely to be caused by the converter, a small reproducible Delphi test case is nevertheless very helpful.

Where possible, a corrected C# version should also be provided to demonstrate the expected translation result.

## Generated Files

Automatically generated files should not be treated as the primary source of a change.

In particular:

- `MockRTL/Converted` is generated from `MockRTL/Source`.
- `TestsGenerated` deliberately contains the unchanged output of D2CSharp.
- Manual test corrections belong under `TestsWorking`.
- `TestsReworked` is derived from the differences between `TestsGenerated` and `TestsWorking`.

Manual changes under `TestsGenerated` would destroy the purpose of that directory as a record of unchanged converter output and should therefore not be made.

## Use of AI Tools

AI tools may be used when developing contributions.

The use of an AI tool does not change the requirements concerning the origin and licensing of contributed code.

In particular, proprietary source code from the Delphi RTL or other non-appropriately licensed components must not be copied, rewritten, or otherwise incorporated into the project without the necessary rights.

Contributions may contain only material that the contributor is legally entitled to provide under the license applicable to the affected file.

## Contribution Licensing

Contributions generally follow the license of the affected file.

- Contributions to Apache-2.0 files are submitted under Apache-2.0. Section 5 of that license applies to intentional submissions for inclusion in the project.
- Contributions to MPL-2.0 files are submitted under MPL-2.0.
- This rule applies to all files carrying the corresponding MPL license notice, not only to specific known helper classes.
- Contributions involving separately licensed third-party material must comply with the license of that material and must be reviewed before acceptance.

By intentionally submitting a contribution for inclusion in the project, the contributor offers that contribution under the license applicable to the affected file unless different terms are explicitly disclosed.

Contributions under different terms cannot be accepted until their licensing has been resolved.

No separately signed Contributor License Agreement is required.

Contributors retain their copyright.

## New Files

For new files, the intended license should be identified in an appropriate source header.

New directly implemented C# runtime helper classes are generally provided under MPL-2.0.

New mock sources, RTL implementations generated from them, tests, and documentation are normally provided under Apache-2.0.

A new file containing MPL-covered code must comply with MPL-2.0 regardless of its name, location, or intended category.

Genuinely ambiguous licensing cases should be discussed before inclusion.

Existing third-party and license notices must not be removed or replaced.

## Rights to Submitted Material

Only material for which the contributor has the required rights may be submitted.

This may include any necessary permission from an employer or other rights holder.

Third-party material must be identified together with its origin and license.

Proprietary Delphi RTL code or other proprietary implementation code must not be copied into the project without the required permission.

This applies regardless of whether the code is copied directly, manually modified, or processed with the assistance of an AI tool.

## Use of Accepted Contributions

Accepted contributions may be used commercially under their respective licenses, including together with Delphi2CSharp, Delphi2Cpp, and other t2t-soft products.

They may also be translated or adapted for other programming languages, including C# and C++.

Other developers receive the same rights granted by the applicable license as t2t-soft.

Apache-2.0 contributions remain subject to the conditions of the Apache License.

MPL-covered source code and its modifications remain subject to MPL-2.0 when distributed in circumstances covered by that license.

Distribution of executable forms containing MPL-covered code requires making the corresponding covered source available as required by the MPL.

These contribution rules do not grant t2t-soft any special relicensing rights.

Independent applications and converters do not have to be disclosed merely because they use the library.

## Changes and Notices

Existing copyright, license, and attribution notices must be preserved.

For Apache-2.0 files, modifications must be marked as required by Section 4 of the Apache License.

For MPL-2.0 files, notices required by Section 3.4 must be preserved.

A contribution should briefly describe what was changed and how the change was verified.

Where relevant, it should also be clear which parts were generated automatically and which were completed or adapted manually.

## Description of a Contribution

A concrete contribution should, where possible, briefly explain:

- which problem or missing feature is being addressed,
- which component is affected,
- how the change was verified,
- whether automatic translation already produces the correct result,
- and whether manual post-processing is still required.

Small, clearly scoped changes are generally easier to review and integrate into further development.

## License Texts

The applicable license texts are available in:

- `LICENSE` – Apache License 2.0
- `LICENSE-MPL-2.0.txt` – Mozilla Public License 2.0

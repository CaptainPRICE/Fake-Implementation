# Fake Implementation

[![Build status](https://ci.appveyor.com/api/projects/status/hrv7m9olfg8rouh6/branch/master?svg=true)](https://ci.appveyor.com/project/CaptainPRICE/fake-implementation/branch/master)  [![Release](https://img.shields.io/github/downloads/CaptainPRICE/Fake-Implementation/latest/total.svg?style=flat&maxAge=30)](https://github.com/CaptainPRICE/Fake-Implementation/releases/latest) [![MIT License](https://img.shields.io/github/license/CaptainPRICE/Fake-Implementation.svg?style=flat&maxAge=30)](LICENSE)
Removes instructions/variables from all of the methods in the given input assembly.

## What is the point of this?

The point of this is being it allows developers to generate a "preview" assembly, that is, all of the implementation is removed out.

### Usage scenario & More info

The main goal of this project is to **provide support to 3rd-party .NET developers to build stuff for Your unreleased/internal software**, and be ahead of time together.
If the XMLDoc file exists, it will be preserved for the generated assembly, and may be shared directly if you wish to provide original documentation to 3rd-party as well.
If the program is run successful, an output assembly will be named `*-preview`.
Linux (with `mono`) & Windows OS are both supported.

![Running on Linux](https://user-images.githubusercontent.com/9789070/43037189-edc80748-8d0a-11e8-8c51-38c4f4bf57ce.png)
![Running on Windows](https://user-images.githubusercontent.com/9789070/43037191-0f217744-8d0b-11e8-96a8-91f347f796e3.png)

Here is a small IL/C# inspection of the generated "preview" assembly (`Mono.Cecil-preview.dll`):
![IL](https://user-images.githubusercontent.com/9789070/43037536-58a641bc-8d0e-11e8-9135-558c79bfcadc.png)
![Decompiled to C#](https://user-images.githubusercontent.com/9789070/43037548-7821e3f2-8d0e-11e8-9239-6e8578d84ee3.png)

The generated "preview" assembly enables 3rd-party users to compile their project, but it is not going to run properly (yes, of course, this is normal and does not matter for us at all; the internal software is yet to be released at that point).
Because, a "preview" assembly is meant to be used as a reference for pure advantages of IDE features (such as IntelliSense, XMLDocs, etc).
Once the internal software becomes released, then 3rd-party users would simply just need to update their reference to use non-preview version.

![Using the generated preview assembly in C#](https://user-images.githubusercontent.com/9789070/43038460-30d32a1e-8d19-11e8-8b06-0d1a1413b696.png)

## Contribution

Visit the [Contributor Guidelines](.github/CONTRIBUTING.md) for more details. All contributors are expected to follow our [Code of Conduct](.github/CODE_OF_CONDUCT.md).

## Support

If you think you have found a bug or have a feature/enhancement request for Fake Implementation, use our [issue tracker](https://github.com/CaptainPRICE/Fake-Implementation/issues/new).

Before opening a new issue, please be kind and search to see if your problem has already been reported. Try to be as detailed as possible in your issue reports.
When creating an issue, clearly explain

* What you were trying to do?
* What you expected to happen?
* What actually happened?
* Steps to reproduce the problem.

Also include any other information you think is relevant to reproduce the problem.

## License

[Fake Implementation](https://github.com/CaptainPRICE/Fake-Implementation) repository/code is freely distributed under the [MIT](LICENSE) license. See [LICENSE](LICENSE) file for more details.

## Credits

It is made possible thanks to all [`dnlib`](https://github.com/0xd4d/dnlib/graphs/contributors) and [`Mono.Cecil`](https://github.com/jbevain/cecil/graphs/contributors) authors.

[CaptainPRICE](https://github.com/CaptainPRICE) for developing Fake Implementation.
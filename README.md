# LuzFaltex.Zitadel

LuzFaltex.Zitadel is a C#/DotNet library for interfacing with the [Zitadel](https://zitadel.com/) management APIs. It is intended for use by service-based or desktop applications, for example automation scripts or Discord bots.

Note: if you are looking to integrate Zitadel authentication into your ASP.NET Core project, [Zitadel.NET](https://github.com/zitadel/zitadel-net) is available for consumption.

## Goals

* Faithful and Accurate -- The library's models will faithfully and accurately represent the data that is presented to or received from the API. No data or structure should meaningfully change between the library receiving it and the user accessing it.

* Robustness -- Error handling is built in to the library and no problems, whether originating from user data, network failures, any other real-life issues will cause the app to crash. Instead, a transparent error will be returned to the caller to allow appropriate handling.

* Asynchronicity and Concurrency -- LuzFaltex.Zitadel aims to be truly asynchronous using best practices for C# and the TPL. It is also concurrent, allowing the processing of and reaction to multiple actions and incoming events at once.

# How to Use LuzFaltex.Zitadel

For instructions on using LuzFaltex.Zitadel, please refer to our [wiki pages](https://github.com/LuzFaltex/LuzFaltex.Zitadel/wiki).


## Versioning

LuzFaltex.Zitadel packages use [SemVer 2.0.0](https://semver.org/spec/v2.0.0.html). The `LuzFaltex.Zitadel` metapackage does not use SemVer, instead versioning itself solely off the API version number. Note that this metapackage implies a dependency on the latest version of the main packages for that API version.

As a note, V0 of the LuzFaltex.Zitadel library is built against V1 of the Zitadel API. Once full API coverage is achieved, we will roll over to V1. From this point onwards, the major version of LuzFaltex.Zitadel will match the Zitadel API version. <strong>Production packages should prefer explicit dependencies.</strong>

## Packages

| Package Name | Description |
|--------------|-------------|
| LuzFaltex.Zitadel.API.Abstractions | This package contains a complete set of type and API abstractions for the Zitadel API. It provides no concrete implementations; rather, it acts as a general, library-agnostic definition of Zitadel's API. |
| LuzFaltex.Zitadel.API | This package contains the default implementation for the abstract API definitions provided by `LuzFaltex.Zitadel.API.Abstractions`. |
| LuzFaltex.Zitadel.Rest | This package contains the default implementations of Zitadel's REST API, complete with client-side sanity checks and rate limiting support. |
| LuzFaltex.Zitadel | This package is a metapackage for LuzFaltex.Zitadel. <strong>Production packages should prefer explicit dependencies.</strong> |

## Status

LuzFaltex.Zitadel is currently in open alpha. Features are expected to not work correctly or be missing entirely. We are building against Version 1 of the API.

# Contributing

Please read our [Contributing Guide](https://github.com/dotnet/runtime/blob/main/.github/CONTRIBUTING.md) for more information.
# Suiran Shop System
- [日本語版](./README.ja.md)

[![CI/CD](https://github.com/mint73/suiran/actions/workflows/main.yml/badge.svg)](https://github.com/mint73/suiran/actions/workflows/main.yml)

This is accounting system for the school festival (customer side), built on [Blazor WebAssembly](https://blazor.net).

## Technology
- Framework: Blazor wasm (.NET8)
- Syntax: Razor (HTML + CSS + C#)

**How to develop this application**
1. [Install *.NET CLI*](https://learn.microsoft.com/en-us/dotnet/core/install/)

1. Install *wasm-tools*
    ```shell
    $ dotnet workload install wasm-tools
    ```

1. Move to target directry
    ```shell
    $ cd suiran
    ```

1. Build this application
    ```shell
    $ dotnet watch run
    ```

1. Access on your browser  
Local Host: http://localhost:5291

## License
Licensed under the [MIT license](./LICENSE).

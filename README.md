# Design Patterns in Naruto

This repository is a hands-on collection of Gang of Four (GoF) design-pattern
examples. Each example uses Naruto-themed classes and scenarios such as
ninja ranks, chakra, jutsu, missions, squads, villages, and shinobi alliances.
The project is primarily written in C# with one behavioral-pattern example
written in Python.

## Pattern coverage

### Creational patterns

| Pattern | Example location | Naruto-themed demonstration |
| --- | --- | --- |
| Abstract Factory | [creational/abstract-factory/](https://github.com/pakbungdesu/design-pattern-naruto/blob/main/creational/abstract-factory/pattern2-abtract-factory.drawio.png) | Creates village-specific weapons, defenses, uniforms, and jutsu. |
| Builder | [creational/builder/](https://github.com/pakbungdesu/design-pattern-naruto/blob/main/creational/builder/pattern3-builder.drawio.png) | Builds specialized ninja types through a director and concrete builders. |
| Factory Method | [creational/factory-method/](https://github.com/pakbungdesu/design-pattern-naruto/blob/main/creational/factory-method/pattern1-factory-method.drawio.png) | An academy and rank hierarchy create Genin, Chunin, Jonin, or Kage products. |
| Prototype | [creational/prototype/](https://github.com/pakbungdesu/design-pattern-naruto/blob/main/creational/prototype/pattern4-prototype.drawio.png) | Clones ninja and jutsu objects, including elemental jutsu variants. |
| Singleton | [creational/singleton/](https://github.com/pakbungdesu/design-pattern-naruto/blob/main/creational/singleton/pattern5-singleton.drawio.png) | Shares a single mission database across the application. |

### Structural patterns

| Pattern | Example location | Naruto-themed demonstration |
| --- | --- | --- |
| Adapter | `structural/adapter/` | Adapts chakra sources for use by battlefield and jutsu code. |
| Bridge | `structural/bridge/` | Separates combat gear abstractions from their construction process. |
| Composite | `structural/composite/` | Represents nested squads and individual ninja as a single tree structure. |
| Decorator | `structural/decorator/` | Adds roles and abilities such as ANBU or tank status to ninja dynamically. |
| Facade | `structural/facade/` | Provides a simplified interface for mission and squad dispatch operations. |
| Flyweight | `structural/flyweight/` | Shares intrinsic ninja or combat data to avoid duplicating repeated state. |
| Proxy | `structural/proxy/` | Controls access to an underlying ninja or village-related resource. |

### Behavioral patterns

| Pattern | Example location | Naruto-themed demonstration |
| --- | --- | --- |
| Chain of Responsibility | `behavioral/chain-of-responsibility/` | Passes requests through handlers with increasing ninja rank or authority. |
| Command | `behavioral/command/` | Encapsulates ninja actions, including undo/invocation behavior, as commands. |
| Iterator | `behavioral/iterator/` | Iterates, filters, sorts, and semantically searches ninja students; implemented in Python. |
| Mediator | `behavioral/mediator/` | Centralizes communication between ninja colleagues. |
| Memento | `behavioral/memento/` | Saves and restores ninja state through a caretaker and originator. |
| Observer | `behavioral/observer/` | Sends mission or status messages to subscribed observers. |
| State | `behavioral/state/` | Changes ninja behavior or rank context as state transitions occur. |
| Strategy | `behavioral/strategy/` | Selects interchangeable ninja or battle strategies at runtime. |
| Template Method | `behavioral/template/` | Defines the common training workflow while allowing subclasses to vary steps. |
| Visitor | `behavioral/visitor/` | Applies operations to ninja and related elements without changing their classes. |

### Combined final example

`final/` combines 6 patterns into a larger shinobi mission and battle
scenario. It uses requirements, villages, ninja, weapons, and chakra in a
combined setup with a facade and combat simulation

Patterns used
1. Facade
2. Factory Method
3. Abstract Factory
4. Composite
5. Decorator
6. Bridge


## Repository layout

```text
design-pattern-naruto/
|-- creational/
|   |-- abstract-factory/
|   |-- builder/
|   |-- factory-method/
|   |-- prototype/
|   `-- singleton/
|-- structural/
|   |-- adapter/
|   |-- bridge/
|   |-- composite/
|   |-- decorator/
|   |-- facade/
|   |-- flyweight/
|   `-- proxy/
|-- behavioral/
|   |-- chain-of-responsibility/
|   |-- command/
|   |-- iterator/
|   |-- mediator/
|   |-- memento/
|   |-- observer/
|   |-- state/
|   |-- strategy/
|   |-- template/
|   `-- visitor/
|-- final/
|   |-- Final.Applications/
|   |-- Final.Models/
|   `-- patterns-final.drawio.png
|-- .gitignore
`-- README.md
```

Each C# pattern is split into two sibling projects:

- `*.Models` or `*.Applications`/`*.Models`: domain classes and pattern
  implementations.
- `*.Application` or `*.Applications`: a console entry point in `Program.cs`
  that demonstrates the pattern.

Application projects reference their matching models project. The repository
does not contain a solution (`.sln`) or a single build-all entry point, so
examples are built and run individually.

Generated directories such as `bin/`, `obj/`, `venv/`, and Python cache files
are excluded through `.gitignore`.

## Prerequisites

### C# examples

Install the .NET 10 SDK. All C# projects currently target `net10.0`.

Verify the installation:

```powershell
dotnet --version
dotnet --list-sdks
```

The repository was built with .NET SDK 10.0.302.

### Python iterator example

Install Python 3. The semantic search example uses:

- `python-dotenv`
- `sentence-transformers`
- their dependencies, including PyTorch

The first semantic search run downloads the `all-MiniLM-L6-v2` model and may
require network access. An optional Hugging Face token can be placed in `.env`
as `HF_TOKEN=...`, although the example does not require it for the bundled
public model.

## Running the C# examples

From the repository root, use `dotnet run --project` with the desired
application project:

```powershell
dotnet run --project "creational\singleton\Singleton.Application\Singleton.Application.csproj"
dotnet run --project "creational\abstract-factory\Abstract.Factory.Application\Abstract.Factory.Application.csproj"
dotnet run --project "structural\composite\Composite.Application\Composite.Application.csproj"
dotnet run --project "behavioral\observer\Observer.Application\Observer.Application.csproj"
dotnet run --project "final\Final.Applications\Final.Applications.csproj"
```

For example, run the Factory Method or Chain of Responsibility pattern:

```powershell
dotnet run --project "creational\factory-method\Factory.Method.Application\Factory.Method.Application.csproj"
dotnet run --project "behavioral\chain-of-responsibility\CoR.Application\CoR.Application.csproj"
```

To restore and build an example without running it:

```powershell
dotnet build "creational\builder\Builder.Application\Builder.Application.csproj"
```

The corresponding output can be found below the project under `bin/` after a
successful build.

### C# project quick reference

```powershell
# Creational
dotnet run --project "creational\abstract-factory\Abstract.Factory.Application\Abstract.Factory.Application.csproj"
dotnet run --project "creational\builder\Builder.Application\Builder.Application.csproj"
dotnet run --project "creational\factory-method\Factory.Method.Application\Factory.Method.Application.csproj"
dotnet run --project "creational\prototype\Prototype.Application\Prototype.Application.csproj"
dotnet run --project "creational\singleton\Singleton.Application\Singleton.Application.csproj"

# Structural
dotnet run --project "structural\adapter\Adapter.Application\Adapter.Application.csproj"
dotnet run --project "structural\bridge\Bridge.Application\Bridge.Application.csproj"
dotnet run --project "structural\composite\Composite.Application\Composite.Application.csproj"
dotnet run --project "structural\decorator\Decorator.Application\Decorator.Application.csproj"
dotnet run --project "structural\facade\Facade.Application\Facade.Application.csproj"
dotnet run --project "structural\flyweight\Flyweight.Application\Flyweight.Application.csproj"
dotnet run --project "structural\proxy\Proxy.Application\Proxy.Application.csproj"

# Behavioral
dotnet run --project "behavioral\chain-of-responsibility\CoR.Application\CoR.Application.csproj"
dotnet run --project "behavioral\command\Command.Application\Command.Application.csproj"
dotnet run --project "behavioral\mediator\Mediator.Application\Mediator.Application.csproj"
dotnet run --project "behavioral\memento\Memento.Applications\Memento.Applications.csproj"
dotnet run --project "behavioral\observer\Observer.Application\Observer.Application.csproj"
dotnet run --project "behavioral\state\State.Applications\State.Applications.csproj"
dotnet run --project "behavioral\strategy\Strategy.Application\Strategy.Application.csproj"
dotnet run --project "behavioral\template\Template.Application\Template.Application.csproj"
dotnet run --project "behavioral\visitor\Visitor.Application\Visitor.Application.csproj"

# Combined
dotnet run --project "final\Final.Applications\Final.Applications.csproj"
```

On PowerShell, run these commands from the repository root. They are also
valid in a standard terminal if the path separators are adapted to the operating
system.

## Running the Python iterator example

Create and activate a virtual environment from the repository root:

```powershell
python -m venv venv
.\venv\Scripts\Activate.ps1
python -m pip install --upgrade pip
python -m pip install python-dotenv sentence-transformers
python "behavioral\iterator\main.py"
```

For Command Prompt on Windows:

```bat
venv\Scripts\activate.bat
python behavioral\iterator\main.py
```

For Linux or macOS:

```bash
python3 -m venv venv
source venv/bin/activate
python -m pip install --upgrade pip
python -m pip install python-dotenv sentence-transformers
python behavioral/iterator/main.py
```

The Python example demonstrates:

1. Filtering Genin by total score.
2. Adding a new student and rerunning the filter.
3. Filtering Chunin by clan.
4. Finding descriptions containing a keyword.
5. Running semantic searches against Jonin descriptions.
6. Sorting all students by total score.
7. Running semantic search across all ranks.

## Development notes

- C# namespace and project names are pattern-specific; use the project
  references in each application project to understand dependencies.
- The C# examples are console applications, so their output is printed to the
  terminal.
- `final/patterns-final.drawio.png` is a diagram asset for the combined example.
- Do not commit `bin/`, `obj/`, `venv/`, or local `.env` values.

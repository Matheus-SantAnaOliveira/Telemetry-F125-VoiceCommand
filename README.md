[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/)
[![Elasticsearch](https://img.shields.io/badge/Elasticsearch-8.x-green.svg)](https://www.elastic.co/elasticsearch/)~

# Telemetry-F125-VoiceCommand

## Overview

Telemetry-F125-VoiceCommand is a real-time telemetry system built for **F1 25**, designed to collect, process, and visualize live racing data while the game is running. The system uses **.NET**, **Elasticsearch**, and **Kibana**, combined with a **local voice command worker**, allowing the user to control dashboards without leaving the race.

The main goal of this project is to eliminate the need for Alt+Tab during gameplay, enabling hands-free interaction with telemetry dashboards in real time.

---

## Project Inspiration and Data Source

This project is based entirely on **official telemetry documentation released by EA** for the F1 series.

📄 **Official Telemetry Documentation:**
(https://forums.ea.com/blog/f1-games-game-info-hub-en/ea-sports™-f1®25-udp-specification/12187347)

All packet structures, data formats, and telemetry behavior follow the specifications provided in this documentation.

---

## High-Level Architecture

The system is composed of three main components:

### 1. Telemetry Worker (.NET)

* Listens to the F1 25 **UDP telemetry stream**.
* Parses raw telemetry packets according to EA specifications.
* Normalizes and processes the data.
* Indexes telemetry data into **Elasticsearch** in real time.

This worker is responsible for all game data ingestion and acts as the backbone of the system.

---

### 2. Voice Command Worker (.NET + Vosk)

* Uses **local speech recognition** (Vosk) for offline voice commands.
* Continuously listens for predefined commands while the game is running.
* Triggers actions such as opening or switching **Kibana dashboards**.

This allows full dashboard control without using the keyboard or leaving the game window.

---

### 3. Kibana Dashboards

Kibana serves as the visualization layer for all telemetry data indexed in Elasticsearch. The dashboards provide rich, real-time insights into the race without requiring any interaction with the game window.

- Built directly on top of Elasticsearch indexes for fast querying and aggregation.

- Visualize key telemetry data including lap times and deltas, car status (fuel, ERS, DRS), session information, tire wear and temperatures, brake temperatures, car damage, weather forecasts, and more.
- Designed specifically for display on a second or third monitor, allowing you to keep critical data in view while racing in full-screen mode on your primary monitor.
- Fully customizable — you can create your own visualizations and dashboards tailored to your racing style (e.g., engineer-style tire management, fuel strategy, or damage overview).

Voice commands from the dedicated worker dynamically control which dashboard is displayed or hidden during gameplay. This enables seamless, hands-free switching between views (e.g., checking tire degradation mid-stint or pulling up damage info after contact) without ever needing to Alt+Tab or touch the keyboard/mouse.

**Note on Deployment (Why No Docker Recommended):**  
Although Docker is commonly used for Elasticsearch and Kibana, this project strongly recommends running them natively on Windows (or via direct binaries) rather than inside Docker under WSL. The EA anti-cheat system (used by F1 25) has been observed to conflict with certain WSL/Docker networking and process monitoring behaviors, which can result in false-positive detections and potential game no open(IN MY Case, use Elastic as native Windows services, resolve the crashs). 
---

## Key Features

* Real-time telemetry ingestion from F1 25
* Fully local processing (no cloud dependency)
* Elasticsearch indexing optimized for time-series data
* Voice-controlled dashboard navigation
* Offline speech recognition
* Multi-monitor friendly setup

---

## Getting Started

1. **Enable UDP Telemetry in F1 25**  
   Go to: Settings → Telemetry Settings → UDP Telemetry → On  
   Set UDP Format to **2025** and Port to **20777** (default).

2. **Start Elasticsearch and Kibana**  
   Recommended: Use Elastic and Kibana as native Windows services.
   (Read: Note on Deployment (Why No Docker Recommended) Section for explain.)

3. **Download the Vosk Portuguese Model**  
   Download `vosk-model-small-pt-0.3` from:  
   https://alphacephei.com/vosk/models/vosk-model-small-pt-0.3.zip  
   Extract it and configure the path in `appsettings.json` (VoiceWorker section).

4. **Import or Create Dashboards in Kibana**  
   ```bash
   dotnet build
   dotnet run --project Api-Telemetry-F1
   dotnet run --project F1VoiceDashboardWorker

5. **Build and Run the Workers**  
    Open Kibana at http://localhost:5601 and create visualizations based on the indexed data.
    (I intend to leave the Jetsons-style dashboards already created accessible in the future, so you can simply import them.)
6. Start Racing and Use Voice Commands!

Markdown## Voice Commands (Examples)

| Command (Portuguese)          | Action                                   |
|-------------------------------|------------------------------------------|
| "Abrir dashboard principal"   | Opens the main overview dashboard        |
| "Mostrar voltas"              | Switches to lap times dashboard          |
| "Mostrar pneus"               | Shows tire wear dashboard                |
| "Mostrar danos"               | Displays car damage dashboard            |
| "Mostrar status do carro"     | Opens car status dashboard               |
| "Fechar dashboard"            | Closes the current dashboard             |

You can easily extend the command list in the voice worker code.

---

## Screenshots

![Positions](screenshots/positions.png)  
*Positions overview dashboard in Kibana*

![Wing Damage](screenshots/wingDamage.png)  
*Wing Damage Dashboard*

![Tyre Use](screenshots/TyreUse.png)  
*Tyre Use Dashboard*

![Voice Command in Action](screenshots/VoiceCommandExample.png)  
*Voice command example during a race*

![Buttons Used during a Race](screenshots/button.png)  
*button used Dashboard*

For more Examples, view the folder "screenshots".

## Project Structure

```text
Telemetry-F125-VoiceCommand
│
├── Api-Telemetry-F1/        Core telemetry ingestion and processing
│   ├── Controllers
│   ├── Models
│   ├── Services
│   ├── TelemetryUtils
│   └── Workers
│
├── F1VoiceDashboardWorker/  Voice command worker
│   ├── Models
│   ├── Services
│   ├── Workers
│   └── VoskModel (ignored)
│
├── F1DashboardUI/           # Optional UI / dashboard launcher
│
└── README.md
```

---

## Voice Recognition Model

This project uses **Vosk** for speech recognition.

The Portuguese model (`vosk-model-small-pt-0.3`) is **not included in the repository** and must be downloaded separately.

🔊 **Model download:**
(https://alphacephei.com/vosk/models)
After downloading, place the model in the configured models directory as described in the voice worker configuration.

---

## Configuration

* `appsettings.json` contains shared configuration.
* Local or environment-specific settings should be placed in:

  * `appsettings.Development.json`
  * `appsettings.Local.json`

These files are intentionally ignored by Git.

---

## Requirements

* Windows
* .NET SDK
* Elasticsearch
* Kibana
* Microphone (for voice commands)
* F1 25

---

## Disclaimer

This project is **not affiliated with EA or Codemasters**.

F1 25 telemetry data is used strictly for educational, experimental, and personal purposes, following the official documentation provided by EA.

---

## Future Improvements

* More advanced voice command grammar
* Additional telemetry packet support
* Dashboard auto-layout based on session type
* Performance optimizations for long sessions

---

## License

License

This project is licensed under the MIT License.

The MIT License allows free use, modification, and distribution of this software, provided that the original copyright notice and license text are included.

You are free to use this project for personal, educational, or commercial purposes.



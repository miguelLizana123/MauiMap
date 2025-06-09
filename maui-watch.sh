#!/bin/bash
/home/miguel/.cargo/bin/watchexec -e cs,xaml -r -- \
  dotnet build -t:Run -f net8.0-android /p:AndroidSdkDirectory=/home/miguel/Android

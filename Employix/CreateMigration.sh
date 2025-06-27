#!/bin/bash

read -p "Enter migration name: " name

dotnet ef migrations add "$name" \
  --project ./src/Employix.Infrastructure \
  --startup-project ./src/Employix.Presentation/Employix.Presentation

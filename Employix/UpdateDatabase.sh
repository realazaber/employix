#!/bin/bash

read -p "Press [Enter] to update the database, or Ctrl+C to cancel..."

dotnet ef database update \
  --project ./src/Employix.Infrastructure \
  --startup-project ./src/Employix.Presentation/Employix.Presentation

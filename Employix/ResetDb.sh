#!/bin/bash

read -p "Press [Enter] to update the database, or Ctrl+C to cancel..."

export DB_CONNECTION="server=localhost;port=3306;database=employix;user=admin;password=root1235*"

dotnet ef database drop \
  --project ./src/Employix.Infrastructure \
  --startup-project ./src/Employix.Presentation/Employix.Presentation

dotnet ef database update \
  --project ./src/Employix.Infrastructure \
  --startup-project ./src/Employix.Presentation/Employix.Presentation


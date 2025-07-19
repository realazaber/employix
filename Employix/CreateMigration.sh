#!/bin/bash

export DB_CONNECTION="server=localhost;port=3306;database=employix;user=admin;password=root1235*"

read -p "Enter migration name: " name

dotnet ef migrations add "$name" \
  --project ./src/Employix.Infrastructure \
  --startup-project ./src/Employix.Presentation/Employix.Presentation

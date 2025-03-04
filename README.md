Azure App Services Deployment

Overview

This repository demonstrates how to deploy an ASP.NET Core 9 application to Azure App Services using GitHub Actions for continuous integration and deployment (CI/CD).

Features

Azure App Services for scalable web hosting.

GitHub Actions for automated build and deployment.

ASP.NET Core 9 for modern web application development.

Prerequisites

Before deploying, ensure you have the following:

An Azure Web App instance set up.

A GitHub repository with your ASP.NET Core 9 project.

The publish profile of your Azure Web App (downloadable from the Azure portal).

Setup Instructions

1. Configure Azure Web App

Log in to Azure Portal.

Navigate to App Services and create a new Web App.

Select .NET 9 (Core) as the runtime stack.

Once created, download the Publish Profile from the Azure Web App settings.

2. Add GitHub Secret

Go to your GitHub repository.

Navigate to Settings > Secrets and variables > Actions.

Click New repository secret.

Name it AZURE_WEBAPP_PUBLISH_PROFILE and paste the contents of the publish profile.

3. GitHub Actions Workflow

The repository includes a GitHub Actions workflow (.github/workflows/deploy.yml) that automates:

Checking out the code.

Setting up .NET 9.

Building and publishing the app.

Deploying to Azure App Services.

Deployment

Push any changes to the main branch, and GitHub Actions will automatically build and deploy the application.

Resources

Azure App Services

GitHub Actions for Azure

ASP.NET Core 9 Documentation




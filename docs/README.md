# Documentation for NginxProxyManager.SDK

This folder contains the documentation for the NginxProxyManager.SDK. The documentation is maintained in Markdown format and can be used to generate the GitHub Wiki.

## Documentation Structure

- `home.md` - The main documentation page that serves as an index
- `*-service.md` - Documentation for each service
- `setup-wiki.md` - Guide for setting up the GitHub Wiki
- `setup-wiki.ps1` - PowerShell script to help set up the GitHub Wiki

## Maintaining Documentation

### Adding New Documentation

1. Create a new Markdown file in this folder
2. Follow the existing format and style
3. Update the `home.md` file to include a link to the new documentation
4. Update the `setup-wiki.ps1` script to include the new file

### Updating Existing Documentation

1. Edit the corresponding Markdown file
2. Test the changes locally
3. Update the GitHub Wiki

### Keeping Documentation in Sync with GitHub Wiki

The documentation in this folder should be kept in sync with the GitHub Wiki. To update the GitHub Wiki:

1. Run the `setup-wiki.ps1` script (after updating it with your GitHub username)
2. Follow the instructions provided by the script
3. Push the changes to GitHub

## Documentation Format

Each service documentation file should follow this format:

```markdown
# Service Name

## Overview

Brief description of the service.

## Methods

### Method Name

Description of the method.

**Parameters:**
- `param1` - Description of param1
- `param2` - Description of param2

**Returns:**
Description of the return value.

**Example:**
```csharp
// Example code
```

## See Also

- [Related Service](Related-Service)
```

## Tools

- `setup-wiki.ps1` - PowerShell script to help set up the GitHub Wiki
- `setup-wiki.md` - Guide for setting up the GitHub Wiki

## Contributing

When contributing to the documentation:

1. Follow the existing format and style
2. Test your changes locally
3. Update both the documentation in this folder and the GitHub Wiki
 
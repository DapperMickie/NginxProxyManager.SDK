# Setting Up GitHub Wiki for NginxProxyManager.SDK

This guide will help you set up the GitHub Wiki for your NginxProxyManager.SDK repository.

## Step 1: Enable the Wiki

1. Go to your GitHub repository
2. Click on the "Wiki" tab
3. If prompted, click "Create the first page"

## Step 2: Create the Home Page

1. Create a new page named "Home"
2. Copy the contents of the `home.md` file from this repository
3. Save the page

## Step 3: Create Service Documentation Pages

For each service, create a new page in the wiki:

1. Click "New Page"
2. Name the page according to the service (e.g., "Proxy-Service", "Certificate-Service")
3. Copy the contents of the corresponding markdown file from the `docs` folder
4. Save the page

## Step 4: Organize the Wiki

1. Go to the Wiki home page
2. Click "Edit" in the top right
3. Add links to all your service pages
4. Save the changes

## Step 5: Set Wiki Permissions (Optional)

1. Go to your repository settings
2. Scroll down to the "Wiki" section
3. Choose who can edit the wiki (Everyone, Collaborators, or Repository administrators)

## Step 6: Clone the Wiki (Optional)

If you want to work on the wiki locally:

```bash
git clone https://github.com/YOUR_USERNAME/NginxProxyManagerSdk.wiki.git
```

Make changes locally, commit, and push back to GitHub.

## Step 7: Keep Documentation in Sync

When you update the documentation in your repository:

1. Update the corresponding files in the `docs` folder
2. Copy the changes to the GitHub Wiki
3. Commit and push the changes

## Additional Tips

- Use the wiki's sidebar for navigation
- Add images and diagrams to make documentation more visual
- Keep the documentation up-to-date with code changes
- Use consistent formatting across all pages 
# Snipe-IT Asset Checkout Automation using Playwright (.NET)

## 📋 Overview

This project demonstrates an automated script built using **Microsoft Playwright for .NET** that logs into the [Snipe-IT demo portal](https://demo.snipeitapp.com), creates a new asset, checks it out to a user, and verifies the asset’s creation and history. The entire test mimics an end-to-end workflow of an IT administrator.

This script was written for a **job screening round** to highlight automation capability, DOM interaction handling, and real-world UI testing logic.

---

## 🔧 Tech Stack
- **Language:** C#
- **Automation Framework:** Microsoft Playwright
- **Browser:** Chromium (non-headless for visibility)
- **Target App:** [Snipe-IT Demo Portal](https://demo.snipeitapp.com)

---

## 🚀 Script Execution Steps

### ✅ 1. Login to the Snipe-IT Demo
- Navigates to the login page.
- Enters predefined credentials (`admin` / `password`).
- Waits for a successful redirect to the homepage.

### ✅ 2. Navigate to the Assets Section
- Clicks on the **Assets** menu.
- Waits for the asset table to load.

### ✅ 3. Create a New Asset
- Clicks on the **Create New** button.
- Waits for the asset form to load.
- Automatically retrieves the **generated Asset Tag**.

### 📝 Note:
> Although we had the option to assign a user during asset creation, we intentionally skipped this to **demonstrate flexibility** in modifying asset properties later — in this case, checking out the asset post-creation.

### ✅ 4. Fill the Asset Form
- Selects a **random company** from the dropdown.
- Selects the **model** (Macbook Pro 13").
- Chooses the status: **Ready to Deploy**.
- Clicks **Save** to create the asset.

### ✅ 5. Post-Creation Validation
- Waits for the success toast.
- Clicks **"Click here to view"** to go to the new asset detail page.

### ✅ 6. Checkout the Asset
- Navigates to the **Checkout** page.
- Opens the **user dropdown**.
- Waits and selects a **random user**.
- Submits the **checkout form**.

### ✅ 7. Verify Asset in Search
- Uses the copied Asset Tag to **search** in the asset list.
- Hits **Enter** to trigger the search.
- Clicks on the matching asset row to re-open the detail view.

### ✅ 8. Open the History Tab
- Clicks the **History** tab on the asset detail page.
- Waits for the history table to load.
- Confirms that the **checkout action** is properly logged.

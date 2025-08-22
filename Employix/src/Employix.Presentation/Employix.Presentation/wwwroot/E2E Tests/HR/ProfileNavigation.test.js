const { test, expect } = require('@playwright/test');


test('HRProfileNavigation', async ({ page }) => {
    await page.goto("Account/Login");
    await page.getByRole('textbox', { name: 'name@example.com' }).click();
    await page.getByRole('textbox', { name: 'name@example.com' }).fill('dumbridge@employix.com');
    await page.getByRole('textbox', { name: 'name@example.com' }).press('Tab');
    await page.getByRole('textbox', { name: 'password' }).fill('Umbridge1235*');
    await page.getByRole('button', { name: 'Log in' }).click();
    await page.waitForTimeout(1500);
    await page.getByRole('button', { name: 'Dolores' }).click();
    await page.getByRole('link', { name: 'Email' }).click();
    await page.getByRole('link', { name: 'Two-factor authentication' }).click();
    await page.getByRole('link', { name: 'Password' }).click();
    await page.getByRole('link', { name: 'Personal data' }).click();
    await page.getByRole('link', { name: 'Password' }).click();
    await page.getByRole('link', { name: 'Profile' }).click();
    await page.getByRole('link', { name: 'Two-factor authentication' }).click();
    await page.getByRole('link', { name: 'Personal data' }).click();
});
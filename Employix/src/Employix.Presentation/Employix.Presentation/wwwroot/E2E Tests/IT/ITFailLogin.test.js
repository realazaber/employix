import { test, expect } from '@playwright/test';

test('ITFailLogin', async ({ page }) => {    
    await page.goto("Account/Login");
    await page.getByRole('textbox', { name: 'name@example.com' }).click();
    await page.getByRole('textbox', { name: 'name@example.com' }).fill('okenobi@employix.com');
    await page.getByRole('textbox', { name: 'name@example.com' }).press('Tab');
    await page.getByRole('textbox', { name: 'password' }).fill('ObiWan1235');
    await page.getByRole('button', { name: 'Log in' }).click();
    await page.getByText('Error: Invalid login attempt.').click();
});
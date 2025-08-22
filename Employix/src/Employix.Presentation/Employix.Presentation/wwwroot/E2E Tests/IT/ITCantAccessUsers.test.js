import { test, expect } from '@playwright/test';

test('ITCantAccessUsers', async ({ page }) => {
    await page.goto('Account/Login');    
    await page.getByRole('textbox', { name: 'name@example.com' }).click();
    await page.getByRole('textbox', { name: 'name@example.com' }).fill('okenobi@employix.com');
    await page.getByRole('textbox', { name: 'name@example.com' }).press('Tab');
    await page.getByRole('textbox', { name: 'password' }).fill('ObiWan1235*');
    await page.getByRole('textbox', { name: 'password' }).press('Tab');
    await page.getByRole('checkbox', { name: 'Remember me' }).press('Tab');    
    await page.getByRole('button', { name: 'Log in' }).click();
    await page.waitForTimeout(1500);
    await page.goto('users');
    await page.getByRole('heading', { name: 'Access denied' }).click();
});
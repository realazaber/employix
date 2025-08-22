import { defineConfig } from "@playwright/test";

export default defineConfig({
    use: {
        baseURL: 'https://localhost:8086/',
        ignoreHTTPSErrors: true,
        headless: false
    }
});

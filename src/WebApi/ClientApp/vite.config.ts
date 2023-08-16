import { sveltekit } from '@sveltejs/kit/vite';
import { defineConfig } from 'vitest/config';

import { readFileSync } from 'fs';
import { join } from 'path';

const baseFolder =
	process.env.APPDATA !== undefined && process.env.APPDATA !== ''
		? `${process.env.APPDATA}/ASP.NET/https`
		: `${process.env.HOME}/.aspnet/https`;

const certificateName = process.env.npm_package_name;

const certFilePath = join(baseFolder, `${certificateName}.pem`);
const keyFilePath = join(baseFolder, `${certificateName}.key`);

export default defineConfig({
	plugins: [sveltekit()],
	test: {
		include: ['src/**/*.{test,spec}.{js,ts}']
	},
	server: {
		https: {
			key: readFileSync(keyFilePath),
			cert: readFileSync(certFilePath)
		},
		port: 5173,
		strictPort: true,
		proxy: {
			'/api': {
				target: 'https://localhost:7255/',
				changeOrigin: true,
				secure: false
			}
		}
		// host: true
	}
});

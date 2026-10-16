import puppeteer from 'puppeteer-core';
import fs from 'node:fs';
import path from 'node:path';

const SCREENSHOTS_DIR = path.resolve('screenshots');
if (!fs.existsSync(SCREENSHOTS_DIR)) {
  fs.mkdirSync(SCREENSHOTS_DIR, { recursive: true });
}

const CHROME_PATH = 'C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe';

async function delay(ms) {
  return new Promise((resolve) => setTimeout(resolve, ms));
}

async function run() {
  console.log('Launching Chrome from:', CHROME_PATH);
  const browser = await puppeteer.launch({
    executablePath: CHROME_PATH,
    headless: 'new',
    args: ['--no-sandbox', '--disable-setuid-sandbox', '--window-size=1440,900']
  });

  const page = await browser.newPage();
  await page.setViewport({ width: 1440, height: 900, deviceScaleFactor: 2 });

  console.log('Navigating to http://localhost:5192...');
  await page.goto('http://localhost:5192', { waitUntil: 'networkidle2', timeout: 30000 });
  await delay(2500);

  // 1. Guest Landing Hero & Search
  console.log('Capturing 01-guest-landing-hero.png...');
  await page.screenshot({ path: path.join(SCREENSHOTS_DIR, '01-guest-landing-hero.png') });

  // 2. Luxury Stays Section (Scroll down slightly)
  console.log('Capturing 02-luxury-stays-and-villas.png...');
  await page.evaluate(() => window.scrollTo(0, 680));
  await delay(1000);
  await page.screenshot({ path: path.join(SCREENSHOTS_DIR, '02-luxury-stays-and-villas.png') });

  // 3. Stay Details Modal
  console.log('Opening Stay Detail Modal...');
  const exploreButtons = await page.$$('button');
  for (const btn of exploreButtons) {
    const text = await page.evaluate(el => el.textContent, btn);
    if (text && text.includes('Explore')) {
      await btn.click();
      break;
    }
  }
  await delay(1500);
  console.log('Capturing 03-stay-details-modal.png...');
  await page.screenshot({ path: path.join(SCREENSHOTS_DIR, '03-stay-details-modal.png') });

  // Close modal
  const closeBtn = await page.$('.fixed.inset-0 button');
  if (closeBtn) await closeBtn.click();
  await delay(800);

  // 4. Global Expeditions Tab
  console.log('Switching to Expeditions tab...');
  const tabs = await page.$$('nav button');
  for (const t of tabs) {
    const text = await page.evaluate(el => el.textContent, t);
    if (text && text.includes('Global Expeditions')) {
      await t.click();
      break;
    }
  }
  await delay(1500);
  await page.evaluate(() => window.scrollTo(0, 0));
  console.log('Capturing 04-global-expeditions.png...');
  await page.screenshot({ path: path.join(SCREENSHOTS_DIR, '04-global-expeditions.png') });

  // 5. Itinerary Planner
  console.log('Switching to Itinerary Planner tab...');
  for (const t of tabs) {
    const text = await page.evaluate(el => el.textContent, t);
    if (text && text.includes('Itinerary Planner')) {
      await t.click();
      break;
    }
  }
  await delay(1500);
  console.log('Capturing 05-itinerary-vacation-planner.png...');
  await page.screenshot({ path: path.join(SCREENSHOTS_DIR, '05-itinerary-vacation-planner.png') });

  // 6. Michelin Dining & Spa
  console.log('Switching to Dining & Spa tab...');
  for (const t of tabs) {
    const text = await page.evaluate(el => el.textContent, t);
    if (text && text.includes('Dining & Spa')) {
      await t.click();
      break;
    }
  }
  await delay(1500);
  console.log('Capturing 06-michelin-dining-and-spa.png...');
  await page.screenshot({ path: path.join(SCREENSHOTS_DIR, '06-michelin-dining-and-spa.png') });

  // 7. Active Trips Drawer
  console.log('Opening My Trips Drawer...');
  const allBtns = await page.$$('button');
  for (const b of allBtns) {
    const text = await page.evaluate(el => el.textContent, b);
    if (text && text.includes('My Trips')) {
      await b.click();
      break;
    }
  }
  await delay(1500);
  console.log('Capturing 07-active-trips-drawer.png...');
  await page.screenshot({ path: path.join(SCREENSHOTS_DIR, '07-active-trips-drawer.png') });

  // Close trips drawer
  const drawerClose = await page.$('.fixed.inset-0.z-50 button');
  if (drawerClose) await drawerClose.click();
  await delay(800);

  // 8. Virtual Concierge Drawer
  console.log('Opening Celeste AI Concierge...');
  const conciergeBtn = await page.$('button[title*="Celeste"]');
  if (conciergeBtn) {
    await conciergeBtn.click();
    await delay(1500);
    console.log('Capturing 08-celeste-ai-concierge.png...');
    await page.screenshot({ path: path.join(SCREENSHOTS_DIR, '08-celeste-ai-concierge.png') });
    // Close concierge
    const ccClose = await page.$('.fixed.inset-0.z-50 button');
    if (ccClose) await ccClose.click();
    await delay(800);
  }

  // 9. PMS Operations Hub: Room Rack
  console.log('Switching to PMS Ops Hub...');
  const pmsBtn = await page.$('button[title*="Operations"]');
  if (pmsBtn) {
    await pmsBtn.click();
    await delay(2000);
    console.log('Capturing 09-pms-room-rack-dashboard.png...');
    await page.screenshot({ path: path.join(SCREENSHOTS_DIR, '09-pms-room-rack-dashboard.png') });

    // 10. Click Room 101 to open Folio Modal
    console.log('Opening Room 101 Folio Inspector...');
    const roomCards = await page.$$('.cursor-pointer');
    for (const card of roomCards) {
      const text = await page.evaluate(el => el.textContent, card);
      if (text && text.includes('101')) {
        await card.click();
        break;
      }
    }
    await delay(1500);
    console.log('Capturing 10-pms-room-folio-inspector.png...');
    await page.screenshot({ path: path.join(SCREENSHOTS_DIR, '10-pms-room-folio-inspector.png') });

    // Close room modal
    const modalClose = await page.$('.fixed.inset-0.z-50 button');
    if (modalClose) await modalClose.click();
    await delay(800);

    // 11. PMS Tour Manifests Tab
    console.log('Switching to PMS Tour Manifests...');
    const pmsTabs = await page.$$('button');
    for (const pt of pmsTabs) {
      const text = await page.evaluate(el => el.textContent, pt);
      if (text && text.includes('Tour Manifests')) {
        await pt.click();
        break;
      }
    }
    await delay(1500);
    console.log('Capturing 11-pms-tour-manifests.png...');
    await page.screenshot({ path: path.join(SCREENSHOTS_DIR, '11-pms-tour-manifests.png') });

    // 12. PMS Housekeeping Tab
    console.log('Switching to PMS Housekeeping...');
    for (const pt of pmsTabs) {
      const text = await page.evaluate(el => el.textContent, pt);
      if (text && text.includes('Housekeeping & Butler')) {
        await pt.click();
        break;
      }
    }
    await delay(1500);
    console.log('Capturing 12-pms-housekeeping-dispatch.png...');
    await page.screenshot({ path: path.join(SCREENSHOTS_DIR, '12-pms-housekeeping-dispatch.png') });
  }

  await browser.close();
  console.log('All screenshots captured successfully in /screenshots folder!');
}

run().catch(console.error);

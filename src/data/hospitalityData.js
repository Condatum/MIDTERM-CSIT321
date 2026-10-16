export const CURRENCIES = {
  USD: { symbol: '$', rate: 1, label: 'USD ($)' },
  EUR: { symbol: '€', rate: 0.92, label: 'EUR (€)' },
  GBP: { symbol: '£', rate: 0.79, label: 'GBP (£)' },
  JPY: { symbol: '¥', rate: 154.5, label: 'JPY (¥)' },
  AUD: { symbol: 'A$', rate: 1.52, label: 'AUD (A$)' }
};

export const STAYS_DATA = [
  {
    id: 'stay-1',
    name: 'Aura Azure Overwater Sanctuary',
    destination: 'Baa Atoll, Maldives',
    category: 'Overwater Villa',
    tag: 'Private Island',
    pricePerNight: 1450,
    rating: 4.98,
    reviewsCount: 142,
    images: [
      'https://images.unsplash.com/photo-1514282401047-d79a71a590e8?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1540555700478-4be289fbecef?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1571896349842-33c89424de2d?auto=format&fit=crop&w=1200&q=80'
    ],
    description: 'Suspended above turquoise crystalline lagoons in a UNESCO Biosphere Reserve. Features direct reef access, private infinity pool, catamaran hammock nets, glass floor viewing portals, and 24-hour dedicated butler service.',
    bedrooms: 2,
    bathrooms: 2,
    maxGuests: 4,
    sizeSqM: 280,
    amenities: [
      'Direct Lagoon Access',
      'Private Freshwater Infinity Pool',
      '24/7 Dedicated Island Butler',
      'Overwater Sun Deck & Hammocks',
      'Outdoor Rainforest Shower',
      'Complimentary Sunset Dolphin Cruise',
      'Subaquatic Wine Cellar Access',
      'High-Speed Satellite Wi-Fi'
    ],
    features: ['Eco-Certified 100% Solar', 'Michelin Chef On-Demand', 'Helipad Arrival'],
    coordinates: { lat: 5.12, lng: 73.1 }
  },
  {
    id: 'stay-2',
    name: 'Palazzo Belvedere Cliffside Manor',
    destination: 'Positano, Amalfi Coast, Italy',
    category: 'Oceanfront Villas',
    tag: 'Historical Luxury',
    pricePerNight: 1850,
    rating: 4.96,
    reviewsCount: 98,
    images: [
      'https://images.unsplash.com/photo-1533105079780-92b9be482077?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1512917774080-9991f1c4c750?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1582719478250-c89cae4dc85b?auto=format&fit=crop&w=1200&q=80'
    ],
    description: 'A 17th-century lemon-grove sanctuary carved into the sheer limestone cliffs above Positano. Panoramic views of the Tyrrhenian Sea, ancient vaulted ceilings, antique terracotta floors, and private funicular access to the sea.',
    bedrooms: 3,
    bathrooms: 3.5,
    maxGuests: 6,
    sizeSqM: 350,
    amenities: [
      'Heated Cliffside Plunge Pool',
      'Private Funicular to Beach Club',
      'Organic Lemon Grove Terrace',
      'Sommelier Wine Tasting Lounge',
      'Private Riva Yacht Mooring',
      'Dedicated Chauffeur & S-Class',
      'Limonaia Outdoor Dining Area',
      'Wood-Fired Neapolitan Pizza Oven'
    ],
    features: ['UNESCO Cultural Heritage', 'Private Speedboat Included', 'Michelin Star Dining'],
    coordinates: { lat: 40.6281, lng: 14.485 }
  },
  {
    id: 'stay-3',
    name: 'Matterhorn Panorama Glass Chalet',
    destination: 'Zermatt, Swiss Alps',
    category: 'Alpine Chalet',
    tag: 'Mountain Sanctuary',
    pricePerNight: 2100,
    rating: 4.99,
    reviewsCount: 86,
    images: [
      'https://images.unsplash.com/photo-1502784444187-359ac186c5bb?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1542314831-068cd1dbfeeb?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1520250497591-112f2f40a3f4?auto=format&fit=crop&w=1200&q=80'
    ],
    description: 'Perched in the high alpine peaks facing the iconic Matterhorn pyramid. Tri-level architectural masterpiece with floor-to-ceiling heated thermal glass, private cedar sauna, outdoor hot tub surrounded by fresh powder, and ski-in/ski-out access.',
    bedrooms: 4,
    bathrooms: 4,
    maxGuests: 8,
    sizeSqM: 420,
    amenities: [
      'Direct Ski-in / Ski-out Access',
      'Matterhorn View Geothermal Hot Tub',
      'Finnish Cedar Sauna & Cryo Plunge',
      'Fireplace Library & Whiskey Bar',
      'Ski & Snowboard Equipment Concierge',
      'Private Swiss Fondue & Raclette Chef',
      'Heated Boot Room',
      'Air Purification & Oxygen Enrichment'
    ],
    features: ['Zero Carbon Geothermal', 'Private Ski Instructor', 'Helicopter Transfer'],
    coordinates: { lat: 45.9765, lng: 7.7491 }
  },
  {
    id: 'stay-4',
    name: 'Serengeti Nomad Acacia Pavilion',
    destination: 'Serengeti National Park, Tanzania',
    category: 'Safari Pavilions',
    tag: 'Wildlife Immersion',
    pricePerNight: 1650,
    rating: 4.97,
    reviewsCount: 112,
    images: [
      'https://images.unsplash.com/photo-1547471080-7cc2caa01a7e?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1516426122078-c23e76319801?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1493976040374-85c8e12f0c0e?auto=format&fit=crop&w=1200&q=80'
    ],
    description: 'Ultra-luxurious canvas and mahogany pavilion situated along the Great Migration migratory corridor. Open-air star-gazing deck, copper soaking tubs with endless savannah views, campfire boma storytelling, and custom open-roof 4x4 game drives.',
    bedrooms: 2,
    bathrooms: 2,
    maxGuests: 4,
    sizeSqM: 220,
    amenities: [
      'Private 4x4 Game Vehicle & Maasai Tracker',
      'Open-Air Stargazing Observation Deck',
      'Hand-Hammered Copper Soaking Tub',
      'Savannah Sunset Boma Fireplace',
      'Solar-Powered Silent Energy',
      'Bush Picnic & Sundowner Experience',
      'Field Wildlife Macro Photography Gear',
      'Artisanal Bush Bar'
    ],
    features: ['Wildlife Conservation Partner', 'Maasai Cultural Council', 'Bush Plane Airstrip'],
    coordinates: { lat: -2.3333, lng: 34.8333 }
  },
  {
    id: 'stay-5',
    name: 'Komorebi Bamboo Forest Ryokan',
    destination: 'Arashiyama, Kyoto, Japan',
    category: 'Cultural Heritage',
    tag: 'Zen Sanctuary',
    pricePerNight: 1380,
    rating: 4.99,
    reviewsCount: 165,
    images: [
      'https://images.unsplash.com/photo-1493976040374-85c8e12f0c0e?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1503899036084-c55cdd92da26?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1528164344705-475426879c0d?auto=format&fit=crop&w=1200&q=80'
    ],
    description: 'Traditional sukiya-zukuri architecture nestled within whispering bamboo groves along the Oi River. Features natural thermal onsen baths fed by mountain mineral springs, authentic tatami mat tea rooms, and Kaiseki multi-course dining.',
    bedrooms: 2,
    bathrooms: 2,
    maxGuests: 4,
    sizeSqM: 190,
    amenities: [
      'Private Hinoki Cypress Hot Spring Onsen',
      'Daily 9-Course Seasonal Kaiseki Banquet',
      'Private Chado Japanese Tea Ceremony',
      'Traditional Zen Rock Meditation Garden',
      'Handwoven Silk Yukata Robes',
      'Shakuhachi Flute Sunset Recital',
      'Curated Green Tea & Sake Cellar',
      'Exclusive Monk-Led Morning Temple Tour'
    ],
    features: ['Ancient Natural Hot Spring', 'Kaiseki Master Chef', 'Ryokan Hospitality'],
    coordinates: { lat: 35.0116, lng: 135.6778 }
  },
  {
    id: 'stay-6',
    name: 'Caldera Horizon Cave Palatial Villa',
    destination: 'Oia, Santorini, Greece',
    category: 'Oceanfront Villas',
    tag: 'Volcanic Caldera',
    pricePerNight: 1720,
    rating: 4.95,
    reviewsCount: 130,
    images: [
      'https://images.unsplash.com/photo-1570077188670-e3a8d69ac5ff?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1469854523086-cc02fe5d8800?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1533105079780-92b9be482077?auto=format&fit=crop&w=1200&q=80'
    ],
    description: 'Sculpted organically out of volcanic rock 300 meters above the Aegean Sea. An expansive terrace with an infinity hydro-pool jutting out over the abyss, world-famous golden sunset panoramas, and Aegean culinary service.',
    bedrooms: 2,
    bathrooms: 2.5,
    maxGuests: 5,
    sizeSqM: 260,
    amenities: [
      'Caldera-Edge Heated Infinity Pool',
      'Indoor Volcanic Rock Steam Cave',
      'Sunken Outdoor Fire Lounge',
      'Private Sunset Champagne Tasting',
      'Helicopter Landing Pad Access',
      'Assyrtiko Wine Cellar',
      'Dedicated Porter & Concierge',
      'Daily Mediterranean Breakfast on Terrace'
    ],
    features: ['Unobstructed Sunset Views', 'Private Yacht Excursion', 'Cave Spa'],
    coordinates: { lat: 36.4618, lng: 25.3753 }
  },
  {
    id: 'stay-7',
    name: 'Uluwatu Ocean Cliff Estate',
    destination: 'Bali, Indonesia',
    category: 'Oceanfront Villas',
    tag: 'Tropical Haven',
    pricePerNight: 1290,
    rating: 4.97,
    reviewsCount: 148,
    images: [
      'https://images.unsplash.com/photo-1537996194471-e657df975ab4?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1580587771525-78b9dba3b914?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1540555700478-4be289fbecef?auto=format&fit=crop&w=1200&q=80'
    ],
    description: 'Perched 150 meters atop dramatic limestone sea cliffs overlooking world-class surf breaks. Features cascading freshwater swimming pools, traditional Balinese teak pavilions, open-air living pavilions, and holistic sound healing retreats.',
    bedrooms: 3,
    bathrooms: 3,
    maxGuests: 6,
    sizeSqM: 380,
    amenities: [
      'Dual-Tier Cliffside Infinity Pool',
      'Daily Balinese Spa & Flower Bath',
      'Private Yoga & Meditation Shala',
      'Private Surf Guide & Board Caddy',
      'Balinese Organic Farm-to-Table Chef',
      'Cliff-Edge Sunset Cocktail Lounge',
      'Traditional Gamelan Evening Blessing',
      'Private Luxury Van & Driver'
    ],
    features: ['Holistic Wellness Center', 'Direct Cliff Access', 'Sustainable Architecture'],
    coordinates: { lat: -8.8291, lng: 115.0849 }
  },
  {
    id: 'stay-8',
    name: 'Glaciares Fjords Eco-Lodge',
    destination: 'Torres del Paine, Patagonia, Chile',
    category: 'Alpine Chalet',
    tag: 'Remote Wilderness',
    pricePerNight: 1950,
    rating: 4.99,
    reviewsCount: 77,
    images: [
      'https://images.unsplash.com/photo-1527004013197-933c4bb611b3?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1464822759023-fed622ff2c3b?auto=format&fit=crop&w=1200&q=80',
      'https://images.unsplash.com/photo-1502784444187-359ac186c5bb?auto=format&fit=crop&w=1200&q=80'
    ],
    description: 'An architectural marvel on the edge of Lake Pehoé facing the granite horns of Torres del Paine. Passive-heated wood and slate design, private wood-fired hot tubs overlooking glaciers, and expedition naturalists at your disposal.',
    bedrooms: 2,
    bathrooms: 2,
    maxGuests: 4,
    sizeSqM: 240,
    amenities: [
      'Lake Pehoé & Glacier Frontage',
      'Patagonian Lenga Wood-Fired Hot Tub',
      'Private Mountain Guide & Naturalist',
      'Traditional Asado Barbecue Feast',
      'Equestrian Ranch & Gaucho Treks',
      'Stargazing Observatory Telescope',
      'Geothermal Floor Heating',
      'High-Latitude Expedition Gear Rental'
    ],
    features: ['100% Carbon Neutral', 'Biosphere Reserve', 'All-Inclusive Expeditions'],
    coordinates: { lat: -51.2532, lng: -72.8814 }
  }
];

export const TOURS_DATA = [
  {
    id: 'tour-1',
    title: 'Serengeti Great Migration Sky & Bush Expedition',
    destination: 'Serengeti, Tanzania',
    category: 'Wildlife Safaris',
    tag: 'Signature Experience',
    pricePerPerson: 890,
    duration: 'Full Day (10 Hours)',
    rating: 5.0,
    reviewsCount: 89,
    difficulty: 'Easy / Moderate',
    groupSize: 'Max 6 guests',
    image: 'https://images.unsplash.com/photo-1516426122078-c23e76319801?auto=format&fit=crop&w=1000&q=80',
    description: 'Drift silently in a hot air balloon over millions of wildebeest and zebras crossing the Mara River at dawn. Follow with a champagne bush breakfast and private 4x4 big cat tracking with our master Maasai tracker.',
    highlights: [
      'Dawn hot air balloon ascent with 360-degree aerial views',
      'Five-star champagne breakfast served beneath an acacia tree in the savannah',
      'Big Five (lion, leopard, rhino, elephant, buffalo) guided safari tracking',
      'Professional telephoto lens wildlife photography mentoring',
      'All conservation fees and park entry passes included'
    ],
    guide: {
      name: 'Joseph Ole Saitoti',
      title: 'Senior Maasai Naturalist & Field Expert (18 yrs experience)',
      avatar: 'https://images.unsplash.com/photo-1534528741775-53994a69daeb?auto=format&fit=crop&w=200&q=80'
    },
    includes: ['Hot Air Balloon Flight', 'Champagne Bush Banquet', '4x4 Game Drive', 'Photography Kit', 'Park Permits']
  },
  {
    id: 'tour-2',
    title: 'Bioluminescent Night Dive & Manta Ray Sanctuary',
    destination: 'Baa Atoll, Maldives',
    category: 'Marine Expeditions',
    tag: 'Underwater Wonder',
    pricePerPerson: 420,
    duration: '4 Hours (Night)',
    rating: 4.98,
    reviewsCount: 114,
    difficulty: 'Moderate',
    groupSize: 'Max 4 guests',
    image: 'https://images.unsplash.com/photo-1544551763-46a013bb70d5?auto=format&fit=crop&w=1000&q=80',
    description: 'Submerge into a world of celestial light. Swim alongside gentle giant Manta Rays feeding amidst millions of glowing bioluminescent phytoplankton, accompanied by our marine biologist.',
    highlights: [
      'Night-time diving / guided snorkeling in protected Hanifaru Bay',
      'Witness glowing phytoplankton illuminating the waters with every movement',
      'Encounter manta rays and harmless nurse sharks in their natural feeding dance',
      'Ultra-violet fluorescent dive torches provided',
      '4K underwater video documentary of your dive included'
    ],
    guide: {
      name: 'Dr. Elena Rostova',
      title: 'Resident Marine Biologist & PADI Master Scuba Diver',
      avatar: 'https://images.unsplash.com/photo-1580489944761-15a19d654956?auto=format&fit=crop&w=200&q=80'
    },
    includes: ['Scuba/Snorkel Gear', 'Marine Biologist Briefing', 'Fluo Torches', 'Boat Charter', '4K Video File']
  },
  {
    id: 'tour-3',
    title: 'Kyoto Secret Temples, Zen Masters & Tea Rite',
    destination: 'Kyoto, Japan',
    category: 'Cultural Heritage',
    tag: 'Exclusive Access',
    pricePerPerson: 550,
    duration: '6 Hours',
    rating: 4.99,
    reviewsCount: 142,
    difficulty: 'Gentle',
    groupSize: 'Private (1-4 guests)',
    image: 'https://images.unsplash.com/photo-1503899036084-c55cdd92da26?auto=format&fit=crop&w=1000&q=80',
    description: 'Gain behind-closed-doors entry to an ancient 800-year-old sub-temple closed to the general public. Engage in private meditation led by the Head Abbot, followed by an authentic Sen-family tea ceremony.',
    highlights: [
      'Private entry before and after public visiting hours',
      'Direct guidance in Zazen meditation by the 24th generation Zen master',
      'Handcrafted Uji ceremonial matcha prepared according to centuries-old ritual',
      'Exclusive stroll through private moss gardens and hidden cedar courtyards',
      'Kaiseki bento lunch box prepared by a three-star culinary atelier'
    ],
    guide: {
      name: 'Kenjiro Takahashi',
      title: 'Kyoto Cultural Historian & Licensed Tea Master',
      avatar: 'https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?auto=format&fit=crop&w=200&q=80'
    },
    includes: ['Private Temple Entry', 'Zen Master Session', 'Tea Master Experience', 'Kaiseki Lunch', 'Private Sedan']
  },
  {
    id: 'tour-4',
    title: 'Amalfi Vintage Riva Yacht & Hidden Grottos',
    destination: 'Positano & Capri, Italy',
    category: 'Coastal Expeditions',
    tag: 'La Dolce Vita',
    pricePerPerson: 780,
    duration: '7 Hours',
    rating: 4.97,
    reviewsCount: 167,
    difficulty: 'Relaxed',
    groupSize: 'Private (Up to 6)',
    image: 'https://images.unsplash.com/photo-1533105079780-92b9be482077?auto=format&fit=crop&w=1000&q=80',
    description: 'Step aboard a pristine handcrafted mahogany Riva Aquarama yacht. Cruise past dramatic cliffs of Positano to the Faraglioni rocks of Capri, swimming in emerald sea grottos with iced Prosecco and fresh antipasti.',
    highlights: [
      'Charter of an authentic classic Riva yacht with professional captain',
      'Swim and snorkel in secluded sea caverns inaccessible from land',
      'Cruise around Capri, stopping at the White and Green Grottos',
      'Reserved seaside lunch table at famous Conca del Sogno restaurant',
      'Endless chilled Franciacorta, local buffalo mozzarella, and fresh figs on board'
    ],
    guide: {
      name: 'Capitano Marco Esposito',
      title: 'Third-Generation Amalfi Coast Captain & Sailor',
      avatar: 'https://images.unsplash.com/photo-1500648767791-00dcc994a43e?auto=format&fit=crop&w=200&q=80'
    },
    includes: ['Riva Yacht Charter', 'Fuel & Skipper', 'Champagne & Antipasti', 'Snorkel Equipment', 'Towels & Sun Care']
  },
  {
    id: 'tour-5',
    title: 'Matterhorn Heli-Ski & High Glacier Traverse',
    destination: 'Zermatt, Switzerland',
    category: 'Alpine Adventures',
    tag: 'Extreme Luxury',
    pricePerPerson: 1250,
    duration: 'Full Day (8 Hours)',
    rating: 5.0,
    reviewsCount: 62,
    difficulty: 'Advanced',
    groupSize: 'Max 4 skiers',
    image: 'https://images.unsplash.com/photo-1551698618-1dfe5d97d256?auto=format&fit=crop&w=1000&q=80',
    description: 'Helicopter flight to the pristine Monte Rosa glacier summit at 4,200m altitude. Carve first tracks down endless untracked powdery couloirs with UIAGM certified mountain guides.',
    highlights: [
      'Air Zermatt private helicopter glacier landing',
      'Over 2,500 vertical meters of untracked virgin powder descent',
      'UIAGM certified mountain guide with satellite avalanche telemetry',
      'Gourmet hot lunch at a secluded high-alpine mountain rifugio',
      'GoPro telemetry helmet footage and drone chase footage'
    ],
    guide: {
      name: 'Beatrix von Bergen',
      title: 'UIAGM High Mountain & Heli-Ski Guide',
      avatar: 'https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?auto=format&fit=crop&w=200&q=80'
    },
    includes: ['Helicopter Drop-off', 'UIAGM Guide', 'ABS Avalanche Airbag', 'Gourmet Lunch', 'Ski Passes']
  },
  {
    id: 'tour-6',
    title: 'Patagonia Perito Moreno Ice Trek & Zodiac Safari',
    destination: 'Torres del Paine & El Calafate',
    category: 'Glacier Expeditions',
    tag: 'Wild Frontier',
    pricePerPerson: 640,
    duration: '8 Hours',
    rating: 4.96,
    reviewsCount: 88,
    difficulty: 'Moderate / Challenging',
    groupSize: 'Max 8 guests',
    image: 'https://images.unsplash.com/photo-1527004013197-933c4bb611b3?auto=format&fit=crop&w=1000&q=80',
    description: 'Strap on steel crampons and walk across deep blue ice crevasses, frozen lagoons, and glacial caves of the living glacier. Conclude with single-malt Patagonian whisky served over million-year-old glacier ice.',
    highlights: [
      'High-speed expedition Zodiac navigation along sheer 60-meter ice walls',
      '3-hour guided ice trek with professional crampons and ice axes',
      'Whisky on pure, crystalline ancient glacier ice',
      'Scenic picnic lunch overlooking the thundering ice calving events',
      'Round-trip private Mercedes Sprinter transfers with naturalist'
    ],
    guide: {
      name: 'Mateo Cárdenas',
      title: 'Glaciologist & Senior Andean Trek Leader',
      avatar: 'https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?auto=format&fit=crop&w=200&q=80'
    },
    includes: ['Ice Crampons & Safety Gear', 'Zodiac Boat Safari', 'Glaciology Guide', 'Lunch & Whisky', 'Park Pass']
  }
];

export const DINING_WELLNESS_DATA = [
  {
    id: 'dining-1',
    name: 'L’Océan Submerged Restaurant & Wine Cellar',
    type: 'Dining',
    destination: 'Maldives',
    cuisine: 'Modern Seafood & French Haute Gastronomy',
    rating: 4.99,
    priceRange: '$$$$',
    image: 'https://images.unsplash.com/photo-1544025162-d76694265947?auto=format&fit=crop&w=800&q=80',
    description: 'Dine 6 meters below the Indian Ocean with 180-degree panoramic glass views of vibrant coral gardens and passing blacktip reef sharks. 7-course degustation curated by 3-star Michelin Chef Jean-Luc Laurent.',
    signature: 'Poached Blue Lobster with Kaffir Lime Emulsion & Osetra Caviar'
  },
  {
    id: 'dining-2',
    name: 'Il Ristorante Belvedere',
    type: 'Dining',
    destination: 'Positano, Italy',
    cuisine: 'Campanian Fine Dining & Fresh Catch',
    rating: 4.97,
    priceRange: '$$$$',
    image: 'https://images.unsplash.com/photo-1559339352-11d035aa65de?auto=format&fit=crop&w=800&q=80',
    description: 'Candlelit terrace perched over the Tyrrhenian Sea. Hand-made scialatielli pasta with wild seafood caught that morning by local fishermen, matched with rare volcanic wines of Mount Vesuvius.',
    signature: 'Handmade Tagliolini with Positano Red Prawns & Amalfi Lemon Zest'
  },
  {
    id: 'spa-1',
    name: 'Aura Thermal & Cryo Ayurvedic Sanctum',
    type: 'Wellness',
    destination: 'Maldives / Kyoto / Swiss Alps',
    cuisine: 'Holistic Spa Treatments',
    rating: 4.98,
    priceRange: '$$$$',
    image: 'https://images.unsplash.com/photo-1540555700478-4be289fbecef?auto=format&fit=crop&w=800&q=80',
    description: 'A fusion of ancient Vedic wisdom, Japanese onsen hydrotherapy, and modern cryotherapy recovery. Personalized herbal oil infusions tailored to your biological dosha balance.',
    signature: '90-min Shirodhara Sacred Oil Flow & Tibetan Singing Bowl Sound Bath'
  },
  {
    id: 'spa-2',
    name: 'Alpine Geothermal & Cedar Detox Ritual',
    type: 'Wellness',
    destination: 'Zermatt, Swiss Alps',
    cuisine: 'Alpine Hydrotherapy',
    rating: 4.99,
    priceRange: '$$$',
    image: 'https://images.unsplash.com/photo-1542314831-068cd1dbfeeb?auto=format&fit=crop&w=800&q=80',
    description: 'Traditional Swiss stone pine and cedar sauna ritual with mineral mountain scrubs, cold mountain plunge pools, and oxygen-infused recovery beds overlooking the snowfields.',
    signature: 'Mountain Arnica & Juniper Deep Muscle Release with Warm Alpine Stones'
  }
];

// Initial Property Management System (PMS) Operational Data
export const INITIAL_PMS_ROOMS = [
  { id: '101', name: 'Azure Overwater 101', type: 'Overwater Villa', status: 'Occupied', guest: 'Lord Harrison Blake', checkOut: '2026-10-18', nights: 5, folioBalance: 7250, vip: true, butler: 'Ramesh' },
  { id: '102', name: 'Azure Overwater 102', type: 'Overwater Villa', status: 'Vacant Clean', guest: null, checkOut: null, nights: 0, folioBalance: 0, vip: false, butler: 'Unassigned' },
  { id: '103', name: 'Azure Overwater 103', type: 'Overwater Villa', status: 'Dirty (Turnover)', guest: 'Departed (Sarah Chen)', checkOut: 'Today 11:00', nights: 3, folioBalance: 0, vip: false, butler: 'Priya' },
  { id: '104', name: 'Azure Lagoon Presidential', type: 'Presidential Suite', status: 'Occupied', guest: 'Dr. Sophia & Alexander Vance', checkOut: '2026-10-22', nights: 7, folioBalance: 14200, vip: true, butler: 'Kavita' },
  { id: '201', name: 'Belvedere Cliffside 201', type: 'Cliffside Manor', status: 'Occupied', guest: 'Marcello Rossi', checkOut: '2026-10-19', nights: 4, folioBalance: 6400, vip: true, butler: 'Gianni' },
  { id: '202', name: 'Belvedere Cliffside 202', type: 'Cliffside Manor', status: 'Maintenance', guest: null, checkOut: null, nights: 0, folioBalance: 0, vip: false, butler: 'None' },
  { id: '301', name: 'Matterhorn Alpine Glass 301', type: 'Alpine Chalet', status: 'Occupied', guest: 'Countess Eleanor Wright', checkOut: '2026-10-20', nights: 6, folioBalance: 12600, vip: true, butler: 'Hans' },
  { id: '302', name: 'Matterhorn Penthouse 302', type: 'Alpine Chalet', status: 'Vacant Clean', guest: 'Arrival at 18:00', checkOut: null, nights: 0, folioBalance: 0, vip: true, butler: 'Lukas' },
  { id: '401', name: 'Serengeti Acacia 401', type: 'Safari Pavilion', status: 'Occupied', guest: 'David & Maya Lin', checkOut: '2026-10-17', nights: 3, folioBalance: 4950, vip: false, butler: 'Juma' },
  { id: '501', name: 'Komorebi Bamboo Ryokan 501', type: 'Ryokan Sanctuary', status: 'Occupied', guest: 'Hiroshi & Yoko Tanaka', checkOut: '2026-10-21', nights: 4, folioBalance: 5520, vip: true, butler: 'Akira' },
  { id: '601', name: 'Caldera Cave Suite 601', type: 'Caldera Suite', status: 'Inspected Ready', guest: null, checkOut: null, nights: 0, folioBalance: 0, vip: false, butler: 'Nikos' },
  { id: '701', name: 'Uluwatu Cliff Villa 701', type: 'Ocean Cliff Estate', status: 'Occupied', guest: 'Liam & Chloe Hemsworth', checkOut: '2026-10-23', nights: 8, folioBalance: 10320, vip: true, butler: 'Wayan' }
];

export const INITIAL_SERVICE_TICKETS = [
  { id: 'TKT-801', room: '101', guest: 'Lord Harrison Blake', type: 'Butler Request', title: 'Vintage Dom Pérignon 2012 on ice', time: '12 mins ago', priority: 'High', status: 'In Progress', assignee: 'Ramesh' },
  { id: 'TKT-802', room: '103', guest: 'Departed', type: 'Housekeeping', title: 'Complete deep clean & sanitization for 16:00 VIP check-in', time: '24 mins ago', priority: 'Urgent', status: 'In Progress', assignee: 'Team Alpha' },
  { id: 'TKT-803', room: '301', guest: 'Countess Eleanor Wright', type: 'Concierge', title: 'Private ski boot fitting & heli-transfer reservation', time: '40 mins ago', priority: 'Medium', status: 'Completed', assignee: 'Hans' },
  { id: 'TKT-804', room: '401', guest: 'David & Maya Lin', type: 'Activity Dispatch', title: 'Dawn hot air balloon departure confirmation & breakfast basket', time: '1 hr ago', priority: 'High', status: 'Pending', assignee: 'Juma' },
  { id: 'TKT-805', room: '202', guest: 'None (Maintenance)', type: 'Engineering', title: 'Infinity plunge pool heating temperature sensor calibration', time: '2 hrs ago', priority: 'Low', status: 'In Progress', assignee: 'Luigi' }
];

export const INITIAL_TOURS_OPERATIONS = [
  { id: 'OPS-T1', tourName: 'Serengeti Great Migration Sky & Bush', date: 'Tomorrow 05:30', participants: 6, maxCapacity: 6, guide: 'Joseph Ole Saitoti', transport: 'Air Balloon #3 + Land Cruiser 4', status: 'Confirmed Full' },
  { id: 'OPS-T2', tourName: 'Bioluminescent Night Dive & Manta Ray', date: 'Tonight 20:00', participants: 4, maxCapacity: 4, guide: 'Dr. Elena Rostova', transport: 'Dhoni Cruiser Coral Star', status: 'Manifest Ready' },
  { id: 'OPS-T3', tourName: 'Kyoto Secret Temples & Zen Masters', date: 'Tomorrow 08:30', participants: 2, maxCapacity: 4, guide: 'Kenjiro Takahashi', transport: 'Private Lexus LS', status: '2 Slots Available' },
  { id: 'OPS-T4', tourName: 'Amalfi Vintage Riva Yacht & Hidden Grottos', date: 'Today 13:00', participants: 5, maxCapacity: 6, guide: 'Capitano Marco Esposito', transport: 'Riva Aquarama "Bella Vita"', status: 'En Route' },
  { id: 'OPS-T5', tourName: 'Matterhorn Heli-Ski & High Glacier', date: 'Tomorrow 07:00', participants: 4, maxCapacity: 4, guide: 'Beatrix von Bergen', transport: 'Air Zermatt Eurocopter AS350', status: 'Weather Permitted' }
];

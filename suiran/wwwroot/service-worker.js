// In development, always fetch from the network and do not enable offline support.
// This is because caching would make development more difficult (changes would not
// be reflected on the first load after each change).
self.addEventListener('fetch', (event) => {
    const url = new URL(event.request.url);

    // Ignore the cache of `/sample-data/item.json`
    if (url.pathname.startsWith('/sample-data/item.json')) {
        event.respondWith(
            fetch(event.request).catch(() => caches.match(event.request))
        );
    // Ignore the cache of `/sample-data/docs.json`
    } else if (url.pathname.startsWith('/sample-data/docs.json')) {
        event.respondWith(
            fetch(event.request).catch(() => caches.match(event.request))
        );
    } else {
        event.respondWith(
            caches.match(event.request).then((response) => {
                return response || fetch(event.request);
            })
        );
    }
});

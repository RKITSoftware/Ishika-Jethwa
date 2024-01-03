// document.addEventListener('DOMContentLoaded', () => {
//     const searchForm = document.getElementById('search-form');
//     const searchInput = document.getElementById('search-input');
//     const weatherCard = document.getElementById('weather-card');
//     const weatherInfo = document.getElementById('weather-info');

//     searchForm.addEventListener('submit', async (e) => {
//         e.preventDefault();
//         const query = searchInput.value.trim();

//         if (query === '') {
//             weatherCard.style.display = 'none';
//             return;
//         }

//         try {
//             const response = await fetch(`https://api.openweathermap.org/data/2.5/weather?q=${query}&appid=5b0219531a7a15107039d1a9faff506d`);
//             if (!response.ok) {
//                 throw new Error(`Weather API request failed with status ${response.status}`);
//             }
//             const data = await response.json();
//             displayWeather(data);
//         } catch (error) {
//             weatherInfo.innerHTML = `<p class="text-danger">Error: ${error.message}</p>`;
//             weatherCard.style.display = 'block';
//         }
//     });

//     function displayWeather(data) {
//         weatherInfo.innerHTML = `
//             <p class="card-text">City: ${data.name}</p>
//             <p class="card-text">Temperature: ${Math.round(data.main.temp - 273.15)}°C</p>
//             <p class="card-text">Weather: ${data.weather[0].description}</p>
//             <p class="card-text">Humidity: ${data.main.humidity}%</p>
//             <p class="card-text">Wind Speed: ${data.wind.speed} m/s</p>
//         `;
//         weatherCard.style.display = 'block';
//     }
// });




// =====================




class OpenWeatherMapService  {
    constructor(apiKey) {
        this.apiKey = apiKey;
    }

    async getWeather(city) {
        const apiUrl = `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${this.apiKey}`;

        try {
            const response = await fetch(apiUrl);
            if (!response.ok) {
                throw new Error(`Weather API request failed with status ${response.status}`);
            }
            return await response.json();
        } catch (error) {
            throw error;
        }
    }
}

class WeatherApp extends OpenWeatherMapService{
    constructor(apiKey,weatherService) { 
        super(apiKey);
        this.weatherService = weatherService;
    }

    async displayWeather(city) {
        try {
            const weatherData = await this.getWeather(city);
            this.renderWeather(weatherData);
        } catch (error) {
            console.error(error);
        }
    }

    renderWeather(data) {
        const displayElement = document.getElementById('weather-display');
        displayElement.innerHTML = `
            <div class="weather-card">
                <h2>${data.name}, ${data.sys.country}</h2>
                <p>Temperature: ${Math.round(data.main.temp - 273.15)}°C</p>
                <p>Weather: ${data.weather[0].description}</p>
                <p>Humidity: ${data.main.humidity}%</p>
                <p>Wind Speed: ${data.wind.speed} m/s</p>
            </div>
        `;
    }
}

document.addEventListener('DOMContentLoaded', () => {
    const apiKey = '5b0219531a7a15107039d1a9faff506d';
    // const openWeatherService = new OpenWeatherMapService(apiKey);
    // console.log(openWeatherService);
    const weatherApp = new WeatherApp(apiKey);

    weatherApp.displayWeather('Rajkot');
});


import { useState, useEffect } from 'react';

import './App.css';

import axios from 'axios';
import { API_WEATHER_FORECAST } from './utils/endpoints';

function App() {
  const [data, setData] = useState([]);

  useEffect(() => {
    axios.get(API_WEATHER_FORECAST).then((res) => {
      try {
        setData(res.data);
      } catch (err) {
        console.log(err);
      }
    });
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        {data.map((temperature, index) => {
          return (
            <div key={index}>
              <p>{temperature.date}</p>
              <p>{temperature.temperatureC}</p>
              <p>{temperature.temperatureF}</p>
              <p>{temperature.summary}</p>
            </div>
          );
        })}
      </header>
    </div>
  );
}

export default App;

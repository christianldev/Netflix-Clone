import { useState, useEffect } from 'react';
import logo from './logo.svg';
import './App.css';

import axios from 'axios';
import { API_WEATER_FORECAST } from './utils/endpoints';

function App() {
  const [data, setData] = useState([]);

  useEffect(() => {
    axios.get(API_WEATER_FORECAST).then((res) => {
      setData(res.data);
    });
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
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

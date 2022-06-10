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
        <section className=" pt-20 pb-12 lg:pt-[120px] lg:pb-[90px]">
          <div className="container">
            <div className="flex flex-wrap items-center justify-between rounded-lg border border-[#e7e7e7] bg-[#1f273b] py-8 px-6 xs:px-10 md:px-8 lg:px-10">
              <div className="w-full md:w-7/12 lg:w-2/3">
                <div className="mb-6 md:mb-0">
                  <h4 className="mb-1 text-xl font-bold text-black xs:text-2xl md:text-xl lg:text-2xl">
                    Netflix Originals
                  </h4>
                  <p className="text-base font-medium text-body-color">
                    Gracias, these sweeties to continue enjoying our site!
                  </p>
                </div>
              </div>
              <div className="w-full md:w-5/12 lg:w-1/3">
                <div className="flex items-center space-x-3 md:justify-end">
                  <button className="inline-flex items-center justify-center rounded-md bg-primary py-[10px] px-8 text-center text-base font-semibold text-white hover:bg-opacity-90">
                    Accept
                  </button>
                  <button className="inline-flex items-center justify-center rounded-md bg-white py-[10px] px-8 text-center text-base font-semibold text-body-color shadow-card hover:bg-primary hover:text-white">
                    Close
                  </button>
                </div>
              </div>
            </div>
          </div>
        </section>
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

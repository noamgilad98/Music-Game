import React, { useState } from 'react';
import axios from 'axios';

function App() {
  const [songUrl, setSongUrl] = useState(null);
  const [gameStatus, setGameStatus] = useState(null);
  const [gameData, setGameData] = useState(null); // New state for game data

  const startGame = async () => {
    try {
      const response = await axios.post('/api/Game/start');
      console.log('Game started:', response.data);
      setGameStatus('Game started successfully!');
      setGameData(response.data); // Set the game data response
    } catch (error) {
      console.error('Error starting game:', error);
      alert('Error starting game. Check the console for details.');
    }
  };

  const playMusic = async () => {
    try {
      const response = await axios.get('/api/Game/randomsong');
      const songUrl = response.data;
      if (songUrl) {
        console.log('Playing song:', songUrl);
        setSongUrl(songUrl);
        const audio = new Audio(songUrl);
        audio.play();
      } else {
        console.log('No song URL returned. Check the server logs for details.');
        alert('No song URL returned. Check the server logs for details.');
      }
    } catch (error) {
      console.error('Error playing music:', error);
      alert('Error playing music. Check the console for details.');
    }
  };

  return (
    <div className="App">
      <h1>Music Game</h1>
      <button onClick={startGame}>Start Game</button>
      <button onClick={playMusic}>Play Music</button>
      {gameStatus && <p>{gameStatus}</p>}
      {gameData && (
        <div>
          <h2>Game Data</h2>
          <pre>{JSON.stringify(gameData, null, 2)}</pre>
        </div>
      )}
      {songUrl && (
        <audio controls autoPlay>
          <source src={songUrl} type="audio/mpeg" />
          Your browser does not support the audio element.
        </audio>
      )}
    </div>
  );
}

export default App;

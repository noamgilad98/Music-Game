import React from 'react';
import axios from 'axios';

function App() {
  const startGame = async () => {
    try {
      const response = await axios.post('/api/Game/start');
      console.log('Game started:', response.data);
    } catch (error) {
      console.error('Error starting game:', error);
      alert('Error starting game. Check the console for details.');
    }
  };

  const playMusic = async () => {
    try {
      const response = await axios.get('/api/Game/randomsong');
      const songUrl = response.data;
      console.log('Playing song:', songUrl);
      const audio = new Audio(songUrl);
      audio.play();
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
    </div>
  );
}

export default App;

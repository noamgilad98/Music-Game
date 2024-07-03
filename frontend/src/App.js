import React, { useState } from 'react';
import { startGame, playerTurn } from './api';

function App() {
  const [game, setGame] = useState(null);

  const handleStartGame = async () => {
    const newGame = await startGame();
    setGame(newGame);
  };

  return (
    <div className="App">
      <h1>Music Game</h1>
      <button onClick={handleStartGame}>Start Game</button>
      {game && (
        <div>
          <h2>Game ID: {game.id}</h2>
          {/* Render additional game information here */}
        </div>
      )}
    </div>
  );
}

export default App;

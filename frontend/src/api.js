import axios from 'axios';

const API_BASE_URL = 'http://localhost:5033/api';

export const startGame = async () => {
  const response = await axios.post(`${API_BASE_URL}/Game/start`);
  return response.data;
};

export const playerTurn = async (playerTurnRequest) => {
  const response = await axios.post(`${API_BASE_URL}/Game/turn`, playerTurnRequest);
  return response.data;
};

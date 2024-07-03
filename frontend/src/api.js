// src/api.js
import axios from 'axios';

const API_BASE_URL = "http://localhost:5033/api/Game";

export const startGame = async () => {
    try {
        const response = await axios.post(`${API_BASE_URL}/start`);
        return response.data;
    } catch (error) {
        console.error("Error starting game", error);
        throw error;
    }
};

export const getRandomSongUrl = async () => {
    try {
        const response = await axios.get(`${API_BASE_URL}/randomsong`);
        return response.data;
    } catch (error) {
        console.error("Error fetching random song", error);
        throw error;
    }
};

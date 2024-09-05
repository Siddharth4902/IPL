import axios from "axios";

const URL = `http://localhost:5245/api/Player/GetPlayers`;
const URL_post = `http://localhost:5245/api/Player/CreatePlayer`;
const URL_Top5 = `http://localhost:5245/api/Player/Top5`;
const URL_Match= `http://localhost:5245/api/Player/GetMatch`;


async function getPlayers() {
  let data = null;

  try {
    let response = await axios.get(URL);
    if (response.status == 200 && response.data !== null) {
      data = await response.data;
    }
  } catch (error) {
    return JSON.stringify(error);
  }
  return data;
}


export const getMatchByDateRange =async(date1,date2)=>{
  let data3 = null;

  try {
    let response = await axios.get("http://localhost:5245/api/Player/GetMatchesByDate?date1="+date1+"&date2="+date2);
    if (response.status == 200 && response.data !== null) {
      data3 = await response.data;
    }
  } catch (error) {
    return JSON.stringify(error);
  }
  return data3;
}


export const  getTop5=async()=> {
    let data1= null;
  
    try {
      let response = await axios.get(URL_Top5);
      if (response.status == 200 && response.data !== null) {
        data1 = await response.data;
      }
    } catch (error) {
      return JSON.stringify(error);
    }
    return data1;
  }

  export const getMatches=async()=>{
    let data2= null;
  
    try {
      let response = await axios.get(URL_Match);
      if (response.status == 200 && response.data !== null) {
        data2 = await response.data;
      }
    } catch (error) {
      return JSON.stringify(error);
    }
    return data2;
  }



export const addPlayer = async (player) => {
  let data = null;
  try {
    let response = await axios.post(URL_post, player);
    console.log(response.data);
    if (response.status === 200 && response.data !== null) {
      data = await response.data;
      console.log("Data from api" + JSON.stringify(data));
    }
  } catch (error) {
    return JSON.stringify(error);
  }
  return data;
};


export default getPlayers;

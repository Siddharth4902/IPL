import { useState, useEffect } from "react";
import { getMatches } from "../Services/PlayerApiServices";

const Matches = () => {
  const [matchList, setmatchList] = useState([]);
  useEffect(() => {
    const getdata = async () => {
      let data2 = await getMatches();
      if (data2 != null) {
        setmatchList(data2);
      }
    };
    getdata();
  });
  return (
    <>
      <h1>List of Matches</h1>
      

        <table className='table table-striped' >
          <thead className='thead-dark'>
            <tr>
              <th >#</th>
              <th>Venue</th>
              <th>Team1</th>
              <th >Team2</th>
              <th>Date</th>
              <th >Fan</th>
            </tr>
          </thead>
          <tbody >
          {matchList.map((q, i) => (
            <tr key={i}>
              <td>{q.match_id}</td>
              <td>{q.venue}</td>
              <td>{q.team1}</td>
              <td>{q.team2}</td>
              <td>{q.date}</td>
              <td>{q.fan}</td>
            </tr>
          ))}
          </tbody>
        </table>
       
      
    </>
  );
};
export default Matches;

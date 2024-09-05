import { useState, useEffect } from "react";
import { getTop5 } from "../Services/PlayerApiServices";

const Top5List = () => {
  const [top5List, settop5List] = useState([]);
  useEffect(() => {
    const getdata = async () => {
      let data1 = await getTop5();
      if (data1 != null) {
        settop5List(data1);
      }
    };
    getdata();
  });
  return (
    <>
      <h1>List of Players : {top5List?.length}</h1>
      

        <table className='table table-striped' >
          <thead className='thead-dark'>
            <tr>
              <th >#</th>
              <th>Name</th>
              <th>Age</th>
              <th >Matches Played</th>
              <th>Role</th>
              <th >Team id</th>
            </tr>
          </thead>
          <tbody >
          {top5List.map((q, i) => (
            <tr key={i}>
              <td>{q.player_id}</td>
              <td>{q.player_name}</td>
              <td>{q.age}</td>
              <td>{q.matches_played}</td>
              <td>{q.role}</td>
              <td>{q.team_id}</td>
            </tr>
          ))}
          </tbody>
        </table>
       
      
    </>
  );
};
export default Top5List;

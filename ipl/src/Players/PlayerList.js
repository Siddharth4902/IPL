import { useState, useEffect } from "react";
import { FaTrashAlt } from "react-icons/fa";
import getPlayers from "../Services/PlayerApiServices";

const PlayerList = () => {
  const [playerList, setPlayerList] = useState([]);
  useEffect(() => {
    const getdata = async () => {
      let data = await getPlayers();
      if (data != null) {
        setPlayerList(data);
      }
    };
    getdata();
  });
  return (
    <>
      <h1>List of Players : {playerList?.length}</h1>
      

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
          {playerList.map((p, i) => (
            <tr key={i}>
              <td>{p.player_id}</td>
              <td>{p.player_name}</td>
              <td>{p.age}</td>
              <td>{p.matches_played}</td>
              <td>{p.role}</td>
              <td>{p.team_id}</td>
              {/* <td>
                <button className="btn btn-danger"><FaTrashAlt /></button>
              </td> */}
            </tr>
          ))}
          </tbody>
        </table>
       
      
    </>
  );
};
export default PlayerList;

import { useState, useEffect } from "react";
import { getMatchByDateRange } from "../Services/PlayerApiServices";

const DateRange = () => {
  const [date1, setdate1] = useState([]);
  const [date2, setdate2] = useState([]);
  const [dateList, setdateList] = useState([]);

  const buttonHandler = async (e) => {
    e.preventDefault();
    
      const getdata = async () => {
        let data3 = await getMatchByDateRange(date1, date2);
        if (data3 != null) {
          setdateList(data3);
        }
      };
      getdata();
      
    
  };

  return (
    <>
      <form className="form-group">
        <div>
          Start Date:
          <input
          className="form-control"
            onChange={(e) => {
              setdate1(e.target.value);
            }}
            type="text"
            placeholder="yyyy-mm-dd"
          />
        </div>
        <div>End Date:
            <input
            className="form-control"
          onChange={(e) => {
            setdate2(e.target.value);
          }}
          type="text"
          placeholder="yyyy-mm-dd"
        />
        </div>
        
        <button className="btn btn-primary m-2 p-3" type="submit" onClick={buttonHandler}>
          Submit
        </button>
      </form>
      <h1>List of Matches</h1>

      <table className="table table-striped">
        <thead className="thead-dark">
          <tr>
            <th>#</th>
            <th>Venue</th>
            <th>Date</th>
            <th>Team1</th>
            <th>Team2</th>
          </tr>
        </thead>
        <tbody>
          {dateList.map((q, i) => (
            <tr key={i}>
              <td>{q.match_id}</td>
              <td>{q.venue}</td>
              <td>{q.match_date}</td>
              <td>{q.team1}</td>
              <td>{q.team2}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
};
export default DateRange;

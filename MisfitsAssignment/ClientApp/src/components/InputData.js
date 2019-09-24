import React, { Component } from 'react';
import { connect } from 'react-redux';

class InputData extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: "",
            input1: "",
            input2: "",
            result: "",
            isDataFound: false,
            items:[],
        }
    }
    usernameChanged(event) {
        this.setState({
            username: event.target.value
        })
    }
    firstValueChange(event) {
        this.setState({
            input1: event.target.value
        })
    }
    secontValueChange(event) {
        this.setState({
            input2: event.target.value
        })
    }
    btnClick(event) {
        const urlCal = `api/calculation`;
        const urlUser = `api/user/getuser/` + this.state.username;
        const urlUserCreate = `api/user`;
        
        fetch(urlUser)
            .then(res => res.json())
            .then(json => {
                this.setState({
                    isDataFound: true,
                    items: json,
                })
            });
        if (this.state.items.length === 0) {
            fetch(urlUserCreate, {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    userid: this.state.username
                })
            });
        }
        fetch(urlUser)
            .then(res => res.json())
            .then(json => {
                this.setState({
                    isDataFound: true,
                    items: json,
                })
            });
        if (this.state.items.length > 0) {
            fetch(urlCal, {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    value_1: this.state.input1,
                    value_2: this.state.input2,
                    userID: '1'
            })
            });
        }


        event.preventDefault();
    }
    render() {
        return (
            <div>
                <div className='form-control'>
                    <h3>Enter Your Value {this.state.result}</h3>
                    <p>
                        <label>
                            User Name
                            <br />
                            <input type="text" name="username" onChange={this.usernameChanged.bind(this)} />
                        </label>
                    </p>
                    <p>
                        <label>
                            First Number
                            <br />
                            <input type="text" name="number1" onChange={this.firstValueChange.bind(this)} />
                        </label>
                    </p>
                    <p>
                        <label>
                            Second Number
                            <br />
                            <input type="text" name="number2" onChange={this.secontValueChange.bind(this)} />
                        </label>
                    </p>
                    <button className='btn btn-default' onClick={this.btnClick.bind(this)} >Submit</button>
                </div>
            </div>
        );
    }
}
export default connect(
    state => state
)(InputData);

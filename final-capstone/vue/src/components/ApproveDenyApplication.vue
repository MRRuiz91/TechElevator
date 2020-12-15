<template>
    <div>
        <div class="text-center">
            <div>
                <b-alert :show="approveSuccess == true" variant="success">Success</b-alert>
                <b-alert :show="dismissCountDown"
                dismissible
                variant="warning"
                @dismissed="dismissCountDown=0"
                @dismiss-count-down="countDownChanged">
                    <p>{{appToUpdate.username}} Successfully Rejected</p>
                    <b-progress
                        variant="warning"
                        :max="dismissSecs"
                        :value="dismissCountDown"
                        height="4px"
                    ></b-progress>
                </b-alert>
            </div>
            <b-button @click="approveApp" size="m" class="mr-5 mb-3" variant="outline-success" >
                Approve Application
            </b-button>
            <b-button @click="denyApp" size="m" class="ml-5 mb-3" variant="outline-warning">
                Reject Application
            </b-button>
        </div>
        <b-table
            striped hover selectable 
            :dark='true' 
            :items="pendingApplications" 
            :fields="fields" sticky-header="500"
            ref="appTable"
            @row-selected="onRowSelect" 
            responsive="sm" 
            :select-mode="selectMode"
            selected-variant="success">
        </b-table>
    </div>
</template>

<script>
import VolunteerService from '../services/VolunteerService'
export default {
    data () {
        return {
            fields : [ 'applicationId', 'firstName', 'lastName', 'Response', 'email', 'phone', 'status'],
            pendingApplications : [],
            appToUpdate : {
                applicationId: 0,
                username: '',
                status: 0,
            },
            approveSuccess: false,
            denySuccess: false,
            selectMode: 'single',
            selected: [],
            dismissSecs: 3,
            dismissCountDown: 0,
        }
    },
    methods: {
        updateStatus() {
            VolunteerService.ApproveOrDenyApplication(this.appToUpdate).then(response => {
                if(response.status == 200){
                    this.approveSuccess = true;
                }
                else{this.showAlert();}
            })/*.catch(error => {});*/
        },
        onRowSelect(item) {
            this.selected = item;
            this.appToUpdate.applicationId = this.selected[0].applicationId;
            this.appToUpdate.username = this.selected[0].username;
            this.appToUpdate.status = this.selected[0].status;
        },
        approveApp(){
            const approveStatus = 2;
            this.appToUpdate.status = approveStatus;
            this.updateStatus();
            this.pendingApplications = this.pendingApplications.filter(app => {
                return app.applicationId != this.appToUpdate.applicationId;
            });
            this.selected = [];
            //this.refreshAppList();
        },
        denyApp(){
            const denyStatus = 3;
            this.appToUpdate.status = denyStatus;
            this.updateStatus();
            this.pendingApplications = this.pendingApplications.filter(app => {
                return app.applicationId != this.appToUpdate.applicationId;
            });
            this.selected = [];
        },
        countDownChanged(dismissCountDown) {
            this.dismissCountDown = dismissCountDown;
        },
        showAlert() {
            this.dismissCountDown = this.dismissSecs;
        },
        clearSelected() {
        this.$refs.appTable.clearSelected()
      }
    },
    created() {
        VolunteerService.getPendingApplications().then(response => {
            this.pendingApplications = response.data;
        });
        
    }
}
</script>

<style>

</style>
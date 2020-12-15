<template>
    <div>
        <div class="text-center">
            <div>
                <b-alert v-if="approveSuccess"><p>Success</p></b-alert>
                <b-alert v-if="denySuccess"></b-alert>
            </div>
            <b-button @click="approveApp" size="m" class="mr-5 mb-3" variant="outline-success" >
                Approve
            </b-button>
            <b-button @click="denyApp" size="m" class="ml-5 mb-3" variant="outline-warning">
                Deny
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
                id: 0,
                username: '',
                status: 0,
            },
            approveSuccess: false,
            denySuccess: false,
            selectMode: 'single',
            selected: []
        }
    },
    methods: {
        updateStatus() {
            VolunteerService.ApproveOrDenyApplication(this.appToUpdate).then(response => {
                if(response.status === 200){
                    this.aproveSuccess = true;
                }
                else{this.denySuccess = true;}
            }).catch(error => {});
        },
        onRowSelect(item) {
            this.selected = item;
            this.appToUpdate.id = this.selected[0].id;
            this.appToUpdate.username = this.selected[0].username;
            this.appToUpdate.status = this.selected[0].status;
        },
        approveApp(){
            const approveStatus = 2;
            this.appToUpdate.status = approveStatus;
            this.updateStatus();
            this.selectedApplications = [];
            this.refreshAppList();
        },
        denyApp(){
            this.selectedApplications[0].status = 3;
            this.updateStatus();
        },
        refreshAppList(){
            VolunteerService.getPendingApplications().then(response => {
            this.$store.commit('UPDATE_PENDING_APPLICATIONS', response.data)
            });
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
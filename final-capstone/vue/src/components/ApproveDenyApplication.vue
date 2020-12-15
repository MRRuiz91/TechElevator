<template>
    <div>
        <div class="text-center">
            <div>
                <b-alert v-if="aproveSuccess"></b-alert>
                <b-alert v-if="denySuccess"></b-alert>
            </div>
            <b-button @click="aproveApp" size="m" class="mr-5 mb-3" variant="outline-success" >
                Approve
            </b-button>
            <b-button @click="denyApp" size="m" class="ml-5 mb-3" variant="outline-warning">
                Deny
            </b-button>
        </div>
        <b-table
            striped hover selectable 
            :dark='true' 
            :items="$store.state.pendingApplications" 
            :fields="fields" sticky-header="500"
            ref="appTable"
            @row-selected="onRowSelected()" 
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
            selectedApplications : [],
            appToUpdate : {
                id: 0,
                username: '',
                status: 0,
            },
            aproveSuccess: false,
            denySuccess: false,
            selectMode: 'single'
        }
    },
    methods: {
        updateStatus() {
            this.VolunteerService.ApproveOrDenyApplication(this.selectedApplications[0]).then(response => {
                if(response.status === 200){
                    this.aproveSuccess = true;
                }
                else{this.denySuccess = true;}
            }).catch(error => {});
        },
        onRowSelect(item) {
            this.$store.commit("SELECT_APPLICATIONS", item);
        },
        aproveApp(){
            this.selectedApplications[0].status = 2;
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
            this.$store.commit('UPDATE_PENDING_APPLICATIONS', response.data)
        });
        
    }
}
</script>

<style>

</style>
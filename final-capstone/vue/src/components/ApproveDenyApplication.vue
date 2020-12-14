<template>
    <div>
        <div class="text-center">
            <b-button size="m" class="mr-5 mb-3" variant="outline-success" >
                Approve
            </b-button>
            <b-button size="m" class="ml-5 mb-3" variant="outline-warning">
                Deny
            </b-button>
        </div>
        <b-table
            striped hover selectable 
            :dark='true' 
            b-table-select-single 
            :items="$store.state.pendingApplications" 
            :fields="fields" sticky-header="500"
            @row-selected="onRowSelected" 
            responsive="sm" 
            selected-variant="success"
        >
        </b-table>
    </div>
</template>

<script>
export default {
    data () {
        return {
            fields : [ 'Name', 'Response', 'Email', 'Phone Number'],
            selectedApplication : {
                id: 0,
                username: '',
                status: 0,
            },
            
        }
    },
    methods: {
        /*updateStatus() {
            this.VolunteerService.ApproveOrDenyApplication(this.SelectedApplication).then(response => {}).catch(error => {});
        },*/
        onRowSelect(items) {
            this.SelectedApplication = items; 
        }
    },
}
</script>

<style>

</style>